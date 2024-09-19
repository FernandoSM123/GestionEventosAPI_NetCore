using eventManagementAPI.Data;
using eventManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace eventManagementAPI.Seeders
{
    public static class CantonSeeder
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (!context.Cantons.Any())
            {

                var cantons = new List<Canton> {
                   new Canton {code=101,provinceId=1,name="San José" },
                   new Canton {code=102,provinceId=1,name="Escazú" },
                   new Canton {code=103,provinceId=1,name="Desamparados" },
                   new Canton {code=104,provinceId=1,name="Puriscal" },
                   new Canton {code=105,provinceId=1,name="Tarrazú"},
                   new Canton {code=106,provinceId=1,name="Aserrí"},
                   new Canton {code=107,provinceId=1,name="Mora"},
                   new Canton {code=108,provinceId=1,name="Goicoechea"},
                   new Canton {code=109,provinceId=1,name="Santa Ana"},
                   new Canton {code=110,provinceId=1,name="Alajuelita"},
                   new Canton {code=111,provinceId=1,name="Vasquez de Coronado"},
                   new Canton {code=112,provinceId=1,name="Acosta"},
                   new Canton {code=113,provinceId=1,name="Tibás"},
                   new Canton {code=114,provinceId=1,name="Moravia"},
                   new Canton {code=115,provinceId=1,name="Montes de Oca"},
                   new Canton {code=116,provinceId=1,name="Turrubares"},
                   new Canton {code=117,provinceId=1,name="Dota"},
                   new Canton {code=118,provinceId=1,name="Curridabat"},
                   new Canton {code=119,provinceId=1,name="Pérez Zeledón"},
                   new Canton {code=120,provinceId=1,name="León Cortés"},
                   new Canton {code=201,provinceId=2,name="Alajuela"},
                   new Canton {code=202,provinceId=2,name="San Ramón"},
                   new Canton {code=203,provinceId=2,name="Grecia"},
                   new Canton {code=204,provinceId=2,name="San Mateo"},
                   new Canton {code=205,provinceId=2,name="Atenas"},
                   new Canton {code=206,provinceId=2,name="Naranjo"},
                   new Canton {code=207,provinceId=2,name="Palmares"},
                   new Canton {code=208,provinceId=2,name="Poás"},
                   new Canton {code=209,provinceId=2,name="Orotina"},
                   new Canton {code=210,provinceId=2,name="San Carlos"},
                   new Canton {code=211,provinceId=2,name="Alfaro Ruiz"},
                   new Canton {code=212,provinceId=2,name="Valverde Vega"},
                   new Canton {code=213,provinceId=2,name="Upala"},
                   new Canton {code=214,provinceId=2,name="Los Chiles"},
                   new Canton {code=215,provinceId=2,name="Guatuso"},
                   new Canton {code=301,provinceId=3,name="Cartago"},
                   new Canton {code=302,provinceId=3,name="Paraíso"},
                   new Canton {code=303,provinceId=3,name="La Unión"},
                   new Canton {code=304,provinceId=3,name="Jiménez"},
                   new Canton {code=305,provinceId=3,name="Turrialba"},
                   new Canton {code=306,provinceId=3,name="Alvarado"},
                   new Canton {code=307,provinceId=3,name="Oreamuno"},
                   new Canton {code=308,provinceId=3,name="El Guarco"},
                   new Canton {code=401,provinceId=4,name="Heredia"},
                   new Canton {code=402,provinceId=4,name="Barva"},
                   new Canton {code=403,provinceId=4,name="Santo Domingo"},
                   new Canton {code=404,provinceId=4,name="Santa Bárbara"},
                   new Canton {code=405,provinceId=4,name="San Rafael"},
                   new Canton {code=406,provinceId=4,name="San Isidro"},
                   new Canton {code=407,provinceId=4,name="Belén"},
                   new Canton {code=408,provinceId=4,name="Flores"},
                   new Canton {code=409,provinceId=4,name="San Pablo"},
                   new Canton {code=410,provinceId=4,name="Sarapiquí "},
                   new Canton {code=501,provinceId=5,name="Liberia"},
                   new Canton {code=502,provinceId=5,name="Nicoya"},
                   new Canton {code=503,provinceId=5,name="Santa Cruz"},
                   new Canton {code=504,provinceId=5,name="Bagaces"},
                   new Canton {code=505,provinceId=5,name="Carrillo"},
                   new Canton {code=506,provinceId=5,name="Cañas"},
                   new Canton {code=507,provinceId=5,name="Abangares"},
                   new Canton {code=508,provinceId=5,name="Tilarán"},
                   new Canton {code=509,provinceId=5,name="Nandayure"},
                   new Canton {code=510,provinceId=5,name="La Cruz"},
                   new Canton {code=511,provinceId=5,name="Hojancha"},
                   new Canton {code=601,provinceId=6,name="Puntarenas"},
                   new Canton {code=602,provinceId=6,name="Esparza"},
                   new Canton {code=603,provinceId=6,name="Buenos Aires"},
                   new Canton {code=604,provinceId=6,name="Montes de Oro"},
                   new Canton {code=605,provinceId=6,name="Osa"},
                   new Canton {code=606,provinceId=6,name="Aguirre"},
                   new Canton {code=607,provinceId=6,name="Golfito"},
                   new Canton {code=608,provinceId=6,name="Coto Brus"},
                   new Canton {code=609,provinceId=6,name="Parrita"},
                   new Canton {code=610,provinceId=6,name="Corredores"},
                   new Canton {code=611,provinceId=6,name="Garabito"},
                   new Canton {code=701,provinceId=7,name="Limón"},
                   new Canton {code=702,provinceId=7,name="Pococí"},
                   new Canton {code=703,provinceId=7,name="Siquirres "},
                   new Canton {code=704,provinceId=7,name="Talamanca"},
                   new Canton {code=705,provinceId=7,name="Matina"},
                   new Canton {code=706,provinceId=7,name="Guácimo"}
                };

                context.Cantons.AddRange(cantons);
                context.SaveChanges();
            }
        }


    }
}
