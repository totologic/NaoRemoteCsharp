using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LitJson;

namespace NaoRemote
{
    public class NaoEventData
    {

        private String _data;
        private Object _extracted;

        public NaoEventData(String data)
        {
            _data = data;
        }

        public T Extract<T>()
        {
            if (_extracted == null)
                _extracted = JsonMapper.ToObject<List<T>>(_data)[0];
            return (T)_extracted;
        }

    }
}
