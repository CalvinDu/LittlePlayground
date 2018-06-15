using AutoMapper.Configuration.Conventions;
using AutoMapper.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper
{
    class Program
    {
        static void Main(string[] args)
        {
            Mapper.Initialize(cfg => {
                cfg.AddMemberConfiguration().AddName<PrePostfixName>(_ => _.AddStrings(p => p.DestinationPostfixes, "DTO"));
                cfg.AddConditionalObjectMapper().Where((s, d) => s.Name == d.Name + "DTO");
            }
            );

            var foo1 = new foo() { name = "Jack",name2="Rose" };
            var boo1 = new boo() { tag = "new", num = 1 };

            var fooDTO1 = Mapper.Map<fooDTO>(foo1);
            var booDTO1 = Mapper.Map<booDTO>(boo1);

            Console.WriteLine(fooDTO1);
            Console.WriteLine(booDTO1);

            Console.ReadKey();
        }
    }
}
