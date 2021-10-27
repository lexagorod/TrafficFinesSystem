using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;
using UniRx;

namespace TrafficFineSystem
{
    public class FinesCostReaderWriter
    {
        private readonly string _trafficFinesInfoPath = "Server/FinesCost.json";
        private ReactiveProperty<Dictionary<string, decimal>> _trafficFinesInfoRX = new ReactiveProperty<Dictionary<string, decimal>>();
        private Dictionary<FineType, decimal> _cachedtrafficFinesInfo;
        public Dictionary<FineType, decimal> TrafficFinesInfo
        {
            get
            {
                if (_cachedtrafficFinesInfo == null)
                {
                    _cachedtrafficFinesInfo = _trafficFinesInfoRX.Value.ToDictionary(f => new FineType(f.Key), f => f.Value);
                }
                return _cachedtrafficFinesInfo;
            }
            set
            {
                _cachedtrafficFinesInfo = value;
                _trafficFinesInfoRX.Value = _cachedtrafficFinesInfo.ToDictionary(f => (string)f.Key, f => f.Value);
            }
        }

        public FinesCostReaderWriter()
        {
            DeserializeTrafficInfo();
            SubscribeReactiveJsonChange();
        }

        private void DeserializeTrafficInfo()
        {
            using (StreamReader file = File.OpenText(_trafficFinesInfoPath))
            {

                var serializeOptions = new JsonSerializerOptions
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                    Converters =
                {
                 new DictionaryTKeyEnumTValueConverter()
                }
                };
                _trafficFinesInfoRX.Value = JsonSerializer.Deserialize<Dictionary<string, decimal>>(file.ReadToEnd(), serializeOptions);
            }
        }

        private void Serialize(Dictionary<string, decimal> finesInfo)
        {
            var serializeOptions = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                Converters =
                {
                 new DictionaryTKeyEnumTValueConverter()
                }
            };
            var trafficInfo = JsonSerializer.Serialize(finesInfo, serializeOptions);
            File.WriteAllText(_trafficFinesInfoPath, trafficInfo);
        }

        private void SubscribeReactiveJsonChange() => _trafficFinesInfoRX.Subscribe(Serialize);
    }
}
