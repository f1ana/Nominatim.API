using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Nominatim.API.Contracts {
    internal class PrivateContractResolver : DefaultContractResolver {
        private static object _locker = new object();

        private readonly static Dictionary<Type, List<MemberInfo>> _serializableMembers = new Dictionary<Type, List<MemberInfo>>();

        protected override List<MemberInfo> GetSerializableMembers(Type objectType) {
            if (_serializableMembers.TryGetValue(objectType, out var members))
                return members;

            var flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
            MemberInfo[] fields = objectType.GetFields(flags);
            var result = fields
                .Concat(objectType.GetProperties(flags).Where(propInfo => propInfo.CanWrite))
                .ToList();

            lock (_locker)
                _serializableMembers[objectType] = result;

            return result;
        }

        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization) {
            return base.CreateProperties(type, MemberSerialization.Fields);
        }
    }
}