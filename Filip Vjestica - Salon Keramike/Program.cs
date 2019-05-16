using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Filip_Vjestica___Salon_Keramike
{
    class Program
    {
        static void Main(string[] args)
        {
            Upiti u = new Upiti();

            //u.napraviTabeleMPObjekti();
            //u.napraviTabeleZaposleni();
            //u.napraviTabelePlocice();
            //u.napraviTabeleBaterije();
            //u.napraviTabeleSaradnici();
            //u.napraviTabeleKupciNaUgovor();
            //u.napraviTabeleDuznici();
            //u.napraviTabeleVozila();
            //u.napraviTabelePorudzbenice();
            //u.napraviTabeleDobavljaci();


            //u.popuniTabeleMPO();
            //u.popuniTabeleZaposleni();
            //u.popuniTabelePlocice();
            //u.popuniTabeleBaterije();
            //u.popuniTabeleSaradnici();
            //u.popuniTabeleKupciNaug();
            //u.popuniTabeleDuznici();
            //u.popuniTabeleVozila();
            //u.popuniTabelePorudzbenice();
            //u.popuniTabeleDobavljaci();


            //Upit 1 
            string upit1 = "SELECT * FROM saradnici ORDER BY kredit DESC";

            //Upit 2 
            string upit2 = "SELECT maloprodajniobjekti.ime,maloprodajniobjekti.grad FROM maloprodajniobjekti WHERE maloprodajniobjekti.nedeljniProfit*4 < 1000000 GROUP BY maloprodajniobjekti.ime,maloprodajniobjekti.grad";

            //Upit 3
            string upit3 = "SELECT dobavljaci.ime,dobavljaci.grad FROM dobavljaci WHERE dobavljaci.dugovanje > 40000";

            //Upit 4
            string upit4 = "SELECT vozila.registracija,maloprodajniobjekti.ime,maloprodajniobjekti.grad FROM vozila INNER JOIN maloprodajniobjekti ON vozila.maloprodajniobjekatid = maloprodajniobjekti.id WHERE vozila.brojmesecnihisporuka < 30";

            //Upit 5
            string upit5 = "SELECT maloprodajniobjekti.ime,maloprodajniobjekti.grad FROM maloprodajniobjekti INNER JOIN zaposleni as z ON z.idObjekta=maloprodajniobjekti.id WHERE z.mesecnaZarada < 45000";

            //Upit 6
            string upit6 = "SELECT porudzbenice.id,porudzbenice.cena,d.ime,d.prezime FROM porudzbenice INNER JOIN baterije as b ON porudzbenice.baterijeid=b.id INNER JOIN duznici as d ON porudzbenice.kupacid=d.id WHERE b.vrsta='Lavabo' AND b.cena > 5000";

            //Upit 7
            string upit7 = "SELECT duznici.id,duznici.ime,duznici.prezime FROM duznici WHERE duznici.preostalirokdana < 20 AND duznici.dug > 15000";

            //Upit 8
            string upit8 = "SELECT zaposleni.ime,zaposleni.prezime FROM zaposleni INNER JOIN maloprodajniobjekti as m on zaposleni.idObjekta=m.id WHERE m.nedeljniProfit > 500000";

            //Upit 9
            string upit9 = "SELECT vozila.registracija,v.ime,v.prezime,m.ime FROM vozila INNER JOIN zaposleni as v ON vozila.vozacid=v.id INNER JOIN maloprodajniobjekti as m ON vozila.maloprodajniobjekatid=m.id WHERE vozila.predjenakm > 100000";

            //Upit 10
            String upit10 = "SELECT kupcinaugovor.imePreduzeca,kupcinaugovor.promet FROM kupcinaugovor ORDER BY kupcinaugovor.promet DESC LIMIT 3";

            //Ovde ubaciti zeljeni upit!
            u.runQuery(upit10);
            //
            Console.ReadLine();

            
        }


    }
}
