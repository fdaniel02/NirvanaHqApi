using System.Collections.Generic;
using NirvanaHqApi.Enums;

namespace NirvanaHqApi.Models
{
    public class NirvanaTask
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public TaskType Type { get; set; }

        public TaskState State { get; set; }

        public List<string> Tags { get; set; }
    }
}
