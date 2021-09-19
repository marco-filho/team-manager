using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TeamManager.Controllers.Utils
{
    public class ResponseFormatter
    {
        public string Message { get; set; }

        public ResponseFormatter(string message) => Message = message;
    }
}
