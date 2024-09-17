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
                   new Canton {id=101,provinceId=1,name="San José" },
                   new Canton {id=102,provinceId=1,name="Escazú" },
                   new Canton {id=103,provinceId=1,name="Desamparados" },
                   new Canton {id=104,provinceId=1,name="Puriscal" },
                   new Canton {id=105,provinceId=1,name="Tarrazú"},
                   new Canton {id=106,provinceId=1,name="Aserrí"},
                   new Canton {id=107,provinceId=1,name="Mora"},
                   new Canton {id=108,provinceId=1,name="Goicoechea"},
                   new Canton {id=109,provinceId=1,name="Santa Ana"},
                   new Canton {id=110,provinceId=1,name="Alajuelita"},
                   new Canton {id=111,provinceId=1,name="Vasquez de Coronado"},
                   new Canton {id=112,provinceId=1,name="Acosta"},
                   new Canton {id=113,provinceId=1,name="Tibás"},
                   new Canton {id=114,provinceId=1,name="Moravia"},
                   new Canton {id=115,provinceId=1,name="Montes de Oca"},
                   new Canton {id=116,provinceId=1,name="Turrubares"},
                   new Canton {id=117,provinceId=1,name="Dota"},
                   new Canton {id=118,provinceId=1,name="Curridabat"},
                   new Canton {id=119,provinceId=1,name="Pérez Zeledón"},
                   new Canton {id=120,provinceId=1,name="León Cortés"},
                   new Canton {id=201,provinceId=2,name="Alajuela"},
                   new Canton {id=202,provinceId=2,name="San Ramón"},
                   new Canton {id=203,provinceId=2,name="Grecia"},
                   new Canton {id=204,provinceId=2,name="San Mateo"},
                   new Canton {id=205,provinceId=2,name="Atenas"},
                   new Canton {id=206,provinceId=2,name="Naranjo"},
                   new Canton {id=207,provinceId=2,name="Palmares"},
                   new Canton {id=208,provinceId=2,name="Poás"},
                   new Canton {id=209,provinceId=2,name="Orotina"},
                   new Canton {id=210,provinceId=2,name="San Carlos"},
                   new Canton {id=211,provinceId=2,name="Alfaro Ruiz"},
                   new Canton {id=212,provinceId=2,name="Valverde Vega"},
                   new Canton {id=213,provinceId=2,name="Upala"},
                   new Canton {id=214,provinceId=2,name="Los Chiles"},
                   new Canton {id=215,provinceId=2,name="Guatuso"},
                   new Canton {id=301,provinceId=3,name="Cartago"},
                   new Canton {id=302,provinceId=3,name="Paraíso"},
                   new Canton {id=303,provinceId=3,name="La Unión"},
                   new Canton {id=304,provinceId=3,name="Jiménez"},
                   new Canton {id=305,provinceId=3,name="Turrialba"},
                   new Canton {id=306,provinceId=3,name="Alvarado"},
                   new Canton {id=307,provinceId=3,name="Oreamuno"},
                   new Canton {id=308,provinceId=3,name="El Guarco"},
                   new Canton {id=401,provinceId=4,name="Heredia"},
                   new Canton {id=402,provinceId=4,name="Barva"},
                   new Canton {id=403,provinceId=4,name="Santo Domingo"},
                   new Canton {id=404,provinceId=4,name="Santa Bárbara"},
                   new Canton {id=405,provinceId=4,name="San Rafael"},
                   new Canton {id=406,provinceId=4,name="San Isidro"},
                   new Canton {id=407,provinceId=4,name="Belén"},
                   new Canton {id=408,provinceId=4,name="Flores"},
                   new Canton {id=409,provinceId=4,name="San Pablo"},
                   new Canton {id=410,provinceId=4,name="Sarapiquí "},
                   new Canton {id=501,provinceId=5,name="Liberia"},
                   new Canton {id=502,provinceId=5,name="Nicoya"},
                   new Canton {id=503,provinceId=5,name="Santa Cruz"},
                   new Canton {id=504,provinceId=5,name="Bagaces"},
                   new Canton {id=505,provinceId=5,name="Carrillo"},
                   new Canton {id=506,provinceId=5,name="Cañas"},
                   new Canton {id=507,provinceId=5,name="Abangares"},
                   new Canton {id=508,provinceId=5,name="Tilarán"},
                   new Canton {id=509,provinceId=5,name="Nandayure"},
                   new Canton {id=510,provinceId=5,name="La Cruz"},
                   new Canton {id=511,provinceId=5,name="Hojancha"},
                   new Canton {id=601,provinceId=6,name="Puntarenas"},
                   new Canton {id=602,provinceId=6,name="Esparza"},
                   new Canton {id=603,provinceId=6,name="Buenos Aires"},
                   new Canton {id=604,provinceId=6,name="Montes de Oro"},
                   new Canton {id=605,provinceId=6,name="Osa"},
                   new Canton {id=606,provinceId=6,name="Aguirre"},
                   new Canton {id=607,provinceId=6,name="Golfito"},
                   new Canton {id=608,provinceId=6,name="Coto Brus"},
                   new Canton {id=609,provinceId=6,name="Parrita"},
                   new Canton {id=610,provinceId=6,name="Corredores"},
                   new Canton {id=611,provinceId=6,name="Garabito"},
                   new Canton {id=701,provinceId=7,name="Limón"},
                   new Canton {id=702,provinceId=7,name="Pococí"},
                   new Canton {id=703,provinceId=7,name="Siquirres "},
                   new Canton {id=704,provinceId=7,name="Talamanca"},
                   new Canton {id=705,provinceId=7,name="Matina"},
                   new Canton {id=706,provinceId=7,name="Guácimo"}
                };

                context.Cantons.AddRange(cantons);
                context.SaveChanges();
            }
        }


    }
}
