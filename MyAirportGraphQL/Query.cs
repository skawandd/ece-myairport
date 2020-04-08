using FLS.MyAirport.EF;
using GraphQL.Types;
using MyAirportGraphQL.GraphQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAirportGraphQL
{
    public class AirportQuery : ObjectGraphType
    {
        //Object Query : permet d'exposer les méthodes pour ...
        /// <summary>
        /// Associe au mot clef bagage l'execusion du lambda
        /// </summary>
        /// <param name="db"></param>
        public AirportQuery(MyAirportContext db)
        {
            Field<ListGraphType<BagageType>>(
                "bagages",
                resolve: context => db.Bagages.ToList());
            /*Field<BagageType>(
                "bagage",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "BagageId" }),
                resolve: context => db.Bagages.First(b => b.BagageID == context.Get//.GetArgument<int>("Bagage")));*/


        }
    }
}
