using FLS.MyAirport.EF;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAirportGraphQL.GraphQL
{
    public class BagageType: ObjectGraphType<Bagage>
    {
        public BagageType()
        {
            Field(x => x.BagageID);
            Field(x => x.Classe);
            Field(x => x.CodeIata);
            Field(x => x.DateCreation);
            Field(x => x.Destination);
            Field(x => x.Escale);
            Field(x => x.Prioritaire);
            Field(x => x.STA);
            Field(x => x.SSUR);
            //Field(x => x.VolID);
        }
    }
}
