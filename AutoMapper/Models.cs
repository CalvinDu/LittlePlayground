using AutoMapper.Configuration.Conventions;
using AutoMapper.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper
{
    class foo
    {
        public string name { get; set; }
        public string name2 { get; set; }
    }
    class fooDTO:Profile
    {
        public string name { get; set; }
        public int number { get; set; }

        public override string ToString()
        {
            return $"name={name},number={number}";
        }
        protected void Configure()
        {
            AddMemberConfiguration().AddName<PrePostfixName>(
                    _ => _.AddStrings(p => p.DestinationPostfixes, "DTO"));
            AddConditionalObjectMapper().Where((s, d) => d.Name == s.Name + "DTO");
        }
    }
    class boo
    {
        public string tag { get; set; }
        public int num { get; set; }

    }
    class booDTO
    {
        public int num { get; set; }
        public override string ToString()
        {
            return $"num={num}";
        }
    }
}
