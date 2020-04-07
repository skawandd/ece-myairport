using FLS.MyAirport.EF;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAirportGraphQL.GraphQLType
{
    public class VolType : ObjectGraphType<Vol>
    {
        public VolType()
        {
            Field(x => x.VolId);
            Field(x => x.CIE);
            Field(x => x.LIG);
            Field(x => x.DHC);
            Field(x => x.PKG);
            Field(x => x.IMM);
            Field(x => x.PAX);
            Field(x => x.DES);
        }
    }
}
