using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Web.Script.Serialization;
using System.Runtime.Serialization;

namespace Benchmark
{
    [ClrJob(baseline: true)]
    public class JsonSerializer
    {
        private const string path = @"C:\Users\CNDUC\Source\Repos\LittlePlayground\Benchmark\Content\TestData.json";

        [GlobalSetup]
        public void Setup()
        {
        }

        [Benchmark]
        public void JsonDeserialize1()
        {
            string contentString;
            var fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            using (var sr = new StreamReader(fs))
            {
                contentString = sr.ReadToEnd();
                sr.Dispose();
                sr.Close();
            }
            var result = JsonConvert.DeserializeObject<IEnumerable<QrCode>>(contentString);
            fs.Dispose();
            fs.Close();
        }

        //必须使用xml
        public void JsonDeserialize2()
        {
            //var js = new DataContractJsonSerializer(typeof(IEnumerable<QrCode>));
            //var fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            //var result = (IEnumerable<QrCode>)js.ReadObject(fs);
            //fs.Dispose();
            //fs.Close();
        }

        [Benchmark]
        public void JsonDeserialize3()
        {
            var jss = new JavaScriptSerializer();
            string contentString;
            var fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            using (var sr = new StreamReader(fs))
            {
                contentString = sr.ReadToEnd();
                sr.Dispose();
                sr.Close();
            }
            fs.Dispose();
            fs.Close();
            var result = jss.Deserialize<IEnumerable<QrCode>>(contentString);
        }
    }

    [DataContract]
    public class QrCode
    {
        [DataMember]
        public string QRString { get; set; }
        [DataMember]
        public string FillingMachineNumber { get; set; }
        [DataMember]
        public DateTimeOffset ScanedTimeStamp { get; set; }
    }
}
