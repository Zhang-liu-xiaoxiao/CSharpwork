using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Homework10
{


    public class SimpleCrawler
    {
        public ConcurrentQueue<String> crawlUrls = new ConcurrentQueue<string>();
        public event Action<SimpleCrawler,int, string, string> PageDownloaded;
        public string startUrl = "";
        private int count = 0;
        private int max = 100;
        static void Main(string[] args)
        {
            SimpleCrawler myCrawler = new SimpleCrawler();
            myCrawler.Start("http://www.cnblogs.com/dstang2000/");
        }

        public void Start(String startUrl)
        {
            SimpleCrawler myCrawler = new SimpleCrawler();
            myCrawler.crawlUrls.Enqueue(startUrl);
            new Thread(myCrawler.Crawl).Start();

        }
        public void Crawl()
        {
            Console.WriteLine("开始爬行了.... ");
            //while (true)
            //{
            //    string current = null;
            //    string url;
            //    while (crawlurls.count > 0)
            //    {
            //        url = (string)crawlurls.dequeue();
            //        current = url;

            //        if (current == null || count > 20) break;
            //        Console.writeline("爬行" + current + "页面!");
            //        string html = download(current); // 下载
            //        count++;
            //        parse(html);//解析,并加入新的链接
            //        console.writeline("爬行结束");
            //    }

            //}

            int complatedCount = 0;//已完成的任务数    
            PageDownloaded += (crawler,index, url, info) => { complatedCount++; };
            List<Task> tasks = new List<Task>();
            while (tasks.Count < max)
            {
                if (!crawlUrls.TryDequeue(out string url))
                {
                    if (complatedCount < tasks.Count)
                    {
                        continue;
                    }
                    else
                    {
                        break;//所有任务都完成，队列无url
                    }
                }
                int index = tasks.Count;
                Task task = Task.Run(() => forDelegate(url,index));
                tasks.Add(task);

            }
            Task.WaitAll(tasks.ToArray());

        }

        public void forDelegate(string url,int index)
        {
            string html = DownLoad(url,index);
            Console.WriteLine("爬行" + url + "页面!");
            Parse(html);
            PageDownloaded(this,index, url, "success");
        }
        public string DownLoad(string url,int index)
        {


            WebClient webClient = new WebClient();
            webClient.Encoding = Encoding.UTF8;
            string html = webClient.DownloadString(url);
       
            string fileName = count.ToString();
            File.WriteAllText(index+".html", html, Encoding.UTF8);
            return html;
        }

        private void Parse(string html)
        {
            string strRef = @"(href|HREF)[]*=[]*[""'][^""'#>]+.html.*?[""']";
            MatchCollection matches = new Regex(strRef).Matches(html);

            //修改部分
            foreach (Match match in matches)
            {
                strRef = match.Value.Substring(match.Value.IndexOf('=') + 1)
                          .Trim('"', '\"', '#', '>');
                if (strRef.Length == 0) continue;
                if (!crawlUrls.Contains(strRef))
                {
                    if (strRef.StartsWith("/"))
                        strRef = startUrl + strRef;
                    else if (strRef.StartsWith("http") || strRef.StartsWith("https")) { }
                    else
                    {
                        strRef = startUrl + strRef;
                    }
                }
                crawlUrls.Enqueue(strRef);
            }

        }
    }

}


