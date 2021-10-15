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

namespace Traffic_fine_system
{
    public class FinesReaderWriter
    {
        private readonly string _trafficFinesPath = "Server/ActualFines.json";
        private ReactiveProperty<Dictionary<string, IssuedFine[]>> _allFinesRx = new ReactiveProperty<Dictionary<string, IssuedFine[]>>();
        private Dictionary<string, IssuedFine[]> _cachedAllFines;
        public Dictionary<string, IssuedFine[]> AllFines
        {
            get
            {
                if (_cachedAllFines == null)
                {
                    _cachedAllFines = _allFinesRx.Value.ToDictionary(f => f.Key, f => f.Value);
                }
                return _cachedAllFines;
            }
            set
            {
                _cachedAllFines = value;
                _allFinesRx.Value = _cachedAllFines.ToDictionary(f => f.Key, f => f.Value);
            }
        }
        public FinesReaderWriter()
        {
            DeserializeFines();
            SubscribeReactiveJsonChange();
        }
        private void DeserializeFines()
        {
            using (StreamReader file = File.OpenText(_trafficFinesPath))
            {

                var serializeOptions = new JsonSerializerOptions
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                    Converters =
                {
                 new DictionaryTKeyEnumTValueConverter()
                }
                };
                try
                {
                    _allFinesRx.Value = JsonSerializer.Deserialize<Dictionary<string, IssuedFine[]>>(file.ReadToEnd(), serializeOptions);
                }
                catch (Exception e)
                {
                    if(e is JsonException)
                        Console.WriteLine("No fines data in json, initializing...");

                    _allFinesRx.Value = new Dictionary<string, IssuedFine[]>();
                }
            }
        }

        private void SerializeFines(Dictionary<string, IssuedFine[]> allTrafficFines)
        {
            var serializeOptions = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                Converters =
                {
                 new DictionaryTKeyEnumTValueConverter()
                }
            };
            var allFines = JsonSerializer.Serialize(allTrafficFines, serializeOptions);
            File.WriteAllText(_trafficFinesPath, allFines);
        }

        private void SubscribeReactiveJsonChange() => _allFinesRx.Subscribe(SerializeFines);
    }
}
