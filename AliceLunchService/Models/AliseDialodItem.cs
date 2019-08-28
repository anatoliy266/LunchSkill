using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AliceLunchService.Models
{
    public class AliseDialodItem
    {
        public int Id { get; set; }
        public int ParentId { get; set; } = 0;
        public int SkillId { get; set; }
        public List<string[]> KeyWords { get; set; }
        public string ItemDesc { get; set; }
    }
}
