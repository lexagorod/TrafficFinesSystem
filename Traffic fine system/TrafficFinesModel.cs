﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using UniRx;

namespace Traffic_fine_system
{
    public class TrafficFinesModel
    {
        private readonly string _trafficFinesInfoPath = "Server/FinesInfo.json";
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

        public TrafficFinesModel()
        {
            DeserializeTrafficInfo();
            SubscribeReactiveJsonChange();
            //_trafficFinesInfoRX.Value = new Dictionary<string, decimal>() { { "dfsdf", 50} };
        }

        private void DeserializeTrafficInfo()
        {
            using (StreamReader file = File.OpenText(_trafficFinesInfoPath))
            {

                var serializeOptions = new JsonSerializerOptions
                {
                    Converters =
                {
                 new DictionaryTKeyEnumTValueConverter()
                }
                };
                _trafficFinesInfoRX.Value = JsonSerializer.Deserialize<Dictionary<string, decimal>>(file.ReadToEnd(), serializeOptions);
            }
        }

        private void Serialize(Dictionary<string, decimal> FinesInfo)
        {
            var serializeOptions = new JsonSerializerOptions
            {
                Converters =
                {
                 new DictionaryTKeyEnumTValueConverter()
                }
            };
            var trafficInfo = JsonSerializer.Serialize(_trafficFinesInfoRX.Value, serializeOptions);
            File.WriteAllText(_trafficFinesInfoPath, trafficInfo);
        }

        private void SubscribeReactiveJsonChange() => _trafficFinesInfoRX.Subscribe(Serialize);
    }
}