using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Filip_Vjestica___Salon_Keramike
{
    class Upiti
    {
        public string runQuery(string upit)
        {
            string query = upit;

            if (query == "")
            {
                Console.WriteLine("Prazan upit!");
                return ("No query inserted!");
            }
            
            string MySqlConnectionString = "datasource=localhost;port=3306;username=root;database=keramikavjestica";
            
            MySqlConnection databaseConnection = new MySqlConnection(MySqlConnectionString);
            
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;

            try
            {

                databaseConnection.Open();

                MySqlDataReader myReader = commandDatabase.ExecuteReader();

                if (myReader.HasRows)
                {
                    Console.WriteLine("Your query generated results");
                    StringBuilder rez = new StringBuilder();

                    while (myReader.Read())
                    {
                        for (int i = 0; i < myReader.FieldCount; i++)
                        {
                            rez.Append(myReader.GetString(i));
                            rez.Append(" ");
                        }
                        rez.Append("\n");
                    }
                    Console.WriteLine(rez.ToString());
                    return rez.ToString();
                }
                else
                {
                    Console.WriteLine("Success");
                }

                databaseConnection.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("Error" + e.Message);
            }
            return "";
        }

        public void napraviTabeleMPObjekti()
        {
            string MySqlConnectionString = "datasource=localhost;port=3306;username=root;database=keramikavjestica";
            MySqlConnection databaseConnection = new MySqlConnection(MySqlConnectionString);
            databaseConnection.Open();
            MySqlCommand tables = new MySqlCommand(@"
                CREATE TABLE maloprodajniObjekti
                (id INT NOT NULL AUTO_INCREMENT,
                ime VARCHAR(50),
                grad VARCHAR(50),
                nedeljniProfit INT,
                PRIMARY KEY (id)) COLLATE='utf8_general_ci' ENGINE=InnoDB;",databaseConnection);
            tables.ExecuteNonQuery();
            databaseConnection.Close();
            Console.WriteLine("Gotovo");
            Console.ReadLine();
            
        }

        public void napraviTabeleZaposleni()
        {
            string MySqlConnectionString = "datasource=localhost;port=3306;username=root;database=keramikavjestica";
            MySqlConnection databaseConnection = new MySqlConnection(MySqlConnectionString);
            databaseConnection.Open();
            MySqlCommand tables = new MySqlCommand(@"
                CREATE TABLE zaposleni
                (id INT NOT NULL AUTO_INCREMENT,
                ime VARCHAR(50),
                prezime VARCHAR(50),
                mesecnaZarada INT,
                idObjekta INT NOT NULL,
                FOREIGN KEY(idObjekta) references maloprodajniobjekti(id),
                PRIMARY KEY (id)) COLLATE='utf8_general_ci' ENGINE=InnoDB;", databaseConnection);
            tables.ExecuteNonQuery();
            databaseConnection.Close();
            Console.WriteLine("Gotovo");
            Console.ReadLine();
        }

        public void napraviTabelePlocice()
        {
            string MySqlConnectionString = "datasource=localhost;port=3306;username=root;database=keramikavjestica";
            MySqlConnection databaseConnection = new MySqlConnection(MySqlConnectionString);
            databaseConnection.Open();
            MySqlCommand tables = new MySqlCommand(@"
                CREATE TABLE plocice
                (id INT NOT NULL AUTO_INCREMENT,
                ime VARCHAR(50),
                vrsta VARCHAR(50),
                cena FLOAT,
                PRIMARY KEY (id)) COLLATE='utf8_general_ci' ENGINE=InnoDB;", databaseConnection);
            tables.ExecuteNonQuery();
            databaseConnection.Close();
            Console.WriteLine("Gotovo");
            Console.ReadLine();
        }

        public void napraviTabeleBaterije()
        {
            string MySqlConnectionString = "datasource=localhost;port=3306;username=root;database=keramikavjestica";
            MySqlConnection databaseConnection = new MySqlConnection(MySqlConnectionString);
            databaseConnection.Open();
            MySqlCommand tables = new MySqlCommand(@"
                CREATE TABLE baterije
                (id INT NOT NULL AUTO_INCREMENT,
                ime VARCHAR(50),
                vrsta VARCHAR(50),
                cena FLOAT,
                PRIMARY KEY (id)) COLLATE='utf8_general_ci' ENGINE=InnoDB;", databaseConnection);
            tables.ExecuteNonQuery();
            databaseConnection.Close();
            Console.WriteLine("Gotovo");
            Console.ReadLine();
        }

        public void napraviTabeleSaradnici()
        {
            string MySqlConnectionString = "datasource=localhost;port=3306;username=root;database=keramikavjestica";
            MySqlConnection databaseConnection = new MySqlConnection(MySqlConnectionString);
            databaseConnection.Open();
            MySqlCommand tables = new MySqlCommand(@"
                CREATE TABLE saradnici
                (id INT NOT NULL AUTO_INCREMENT,
                ime VARCHAR(50),
                prezime VARCHAR(50),
                vrsta VARCHAR(50),
                kredit INT,
                PRIMARY KEY (id)) COLLATE='utf8_general_ci' ENGINE=InnoDB;", databaseConnection);
            tables.ExecuteNonQuery();
            databaseConnection.Close();
            Console.WriteLine("Gotovo");
            Console.ReadLine();
        }

        public void napraviTabeleKupciNaUgovor()
        {
            string MySqlConnectionString = "datasource=localhost;port=3306;username=root;database=keramikavjestica";
            MySqlConnection databaseConnection = new MySqlConnection(MySqlConnectionString);
            databaseConnection.Open();
            MySqlCommand tables = new MySqlCommand(@"
                CREATE TABLE kupcinaugovor
                (id INT NOT NULL AUTO_INCREMENT,
                imePreduzeca VARCHAR(50),
                promet INT,
                grad VARCHAR(50),
                PRIMARY KEY (id)) COLLATE='utf8_general_ci' ENGINE=InnoDB;", databaseConnection);
            tables.ExecuteNonQuery();
            databaseConnection.Close();
            Console.WriteLine("Gotovo");
            Console.ReadLine();
        }

        public void napraviTabeleDuznici()
        {
            string MySqlConnectionString = "datasource=localhost;port=3306;username=root;database=keramikavjestica";
            MySqlConnection databaseConnection = new MySqlConnection(MySqlConnectionString);
            databaseConnection.Open();
            MySqlCommand tables = new MySqlCommand(@"
                CREATE TABLE duznici
                (id INT NOT NULL AUTO_INCREMENT,
                ime VARCHAR(50),
                prezime VARCHAR(50),
                dug INT,
                preostalirokdana INT,
                PRIMARY KEY (id)) COLLATE='utf8_general_ci' ENGINE=InnoDB;", databaseConnection);
            tables.ExecuteNonQuery();
            databaseConnection.Close();
            Console.WriteLine("Gotovo");
            Console.ReadLine();
        }

        public void napraviTabeleVozila()
        {
            string MySqlConnectionString = "datasource=localhost;port=3306;username=root;database=keramikavjestica";
            MySqlConnection databaseConnection = new MySqlConnection(MySqlConnectionString);
            databaseConnection.Open();
            MySqlCommand tables = new MySqlCommand(@"
                CREATE TABLE vozila
                (id INT NOT NULL AUTO_INCREMENT,
                registracija VARCHAR(50),
                vozacid INT NOT NULL,
                maloprodajniobjekatid INT NOT NULL,
                brojmesecnihisporuka INT,
                predjenakm FLOAT,
                FOREIGN KEY (vozacid) references zaposleni(id),
                FOREIGN KEY (maloprodajniobjekatid) references maloprodajniobjekti(id),
                PRIMARY KEY (id)) COLLATE='utf8_general_ci' ENGINE=InnoDB;", databaseConnection);
            tables.ExecuteNonQuery();
            databaseConnection.Close();
            Console.WriteLine("Gotovo");
            Console.ReadLine();
        }

        public void napraviTabelePorudzbenice()
        {
            string MySqlConnectionString = "datasource=localhost;port=3306;username=root;database=keramikavjestica";
            MySqlConnection databaseConnection = new MySqlConnection(MySqlConnectionString);
            databaseConnection.Open();
            MySqlCommand tables = new MySqlCommand(@"
                CREATE TABLE porudzbenice
                (id INT NOT NULL AUTO_INCREMENT,
                cena FLOAT,
                kupacid INT NOT NULL,
                plocicaid INT NOT NULL,
                baterijeid INT NOT NULL,
                FOREIGN KEY (kupacid) references duznici(id),
                FOREIGN KEY (plocicaid) references plocice(id),
                FOREIGN KEY (baterijeid) references baterije(id),
                PRIMARY KEY (id)) COLLATE='utf8_general_ci' ENGINE=InnoDB;", databaseConnection);
            tables.ExecuteNonQuery();
            databaseConnection.Close();
            Console.WriteLine("Gotovo");
            Console.ReadLine();
        }

        public void napraviTabeleDobavljaci()
        {
            string MySqlConnectionString = "datasource=localhost;port=3306;username=root;database=keramikavjestica";
            MySqlConnection databaseConnection = new MySqlConnection(MySqlConnectionString);
            databaseConnection.Open();
            MySqlCommand tables = new MySqlCommand(@"
                CREATE TABLE dobavljaci
                (id INT NOT NULL AUTO_INCREMENT,
                ime VARCHAR(50),
                grad VARCHAR(50),
                promet INT,
                dugovanje INT,
                PRIMARY KEY (id)) COLLATE='utf8_general_ci' ENGINE=InnoDB;", databaseConnection);
            tables.ExecuteNonQuery();
            databaseConnection.Close();
            Console.WriteLine("Gotovo");
            Console.ReadLine();
        }

        public void popuniTabeleMPO()
        {
            string MySqlConnectionString = "datasource=localhost;port=3306;username=root;database=keramikavjestica";
            MySqlConnection databaseConnection = new MySqlConnection(MySqlConnectionString);
            databaseConnection.Open();
            MySqlCommand tables = new MySqlCommand(@"
                INSERT INTO maloprodajniobjekti VALUES(0,'Keramika BP1','Backa Palanka',400000);
                INSERT INTO maloprodajniobjekti VALUES(0,'Keramika BP2','Backa Palanka',450000);
                INSERT INTO maloprodajniobjekti VALUES(0,'Keramika BP3','Backa Palanka',500000);
                INSERT INTO maloprodajniobjekti VALUES(0,'Keramika BP4','Backa Palanka',300000);
                INSERT INTO maloprodajniobjekti VALUES(0,'Keramika BP5','Backa Palanka',390000);
                INSERT INTO maloprodajniobjekti VALUES(0,'Keramika NS1','Novi Sad',390000);
                INSERT INTO maloprodajniobjekti VALUES(0,'Keramika NS2','Novi Sad',290000);
                INSERT INTO maloprodajniobjekti VALUES(0,'Keramika NS3','Novi Sad',690400);
                INSERT INTO maloprodajniobjekti VALUES(0,'Keramika NS4','Novi Sad',495050);
                INSERT INTO maloprodajniobjekti VALUES(0,'Keramika NS5','Novi Sad',540500);
                INSERT INTO maloprodajniobjekti VALUES(0,'Keramika Nis1','Nis',140500);
                INSERT INTO maloprodajniobjekti VALUES(0,'Keramika Nis2','Nis',240660);
                INSERT INTO maloprodajniobjekti VALUES(0,'Keramika Nis3','Nis',350600);
                INSERT INTO maloprodajniobjekti VALUES(0,'Keramika Nis4','Nis',544500);
                INSERT INTO maloprodajniobjekti VALUES(0,'Keramika Nis5','Nis',140660);
                INSERT INTO maloprodajniobjekti VALUES(0,'Keramika Subotica1','Subotica',140660);
                INSERT INTO maloprodajniobjekti VALUES(0,'Keramika Subotica1','Subotica',340660);
                INSERT INTO maloprodajniobjekti VALUES(0,'Keramika Subotica1','Subotica',445660);
                INSERT INTO maloprodajniobjekti VALUES(0,'Keramika Subotica1','Subotica',511660);
                INSERT INTO maloprodajniobjekti VALUES(0,'Keramika Subotica1','Subotica',243667);", databaseConnection);
            tables.ExecuteNonQuery();
            databaseConnection.Close();
            Console.WriteLine("Gotovo");
            Console.ReadLine();
        }

        public void popuniTabeleZaposleni()
        {
            string MySqlConnectionString = "datasource=localhost;port=3306;username=root;database=keramikavjestica";
            MySqlConnection databaseConnection = new MySqlConnection(MySqlConnectionString);
            databaseConnection.Open();
            MySqlCommand tables = new MySqlCommand(@"
                        INSERT INTO zaposleni VALUES(0,'Dimitrije','Kozomora',50000,1);
                        INSERT INTO zaposleni VALUES(0,'Igor','Anon',40000,2);
                        INSERT INTO zaposleni VALUES(0,'Marko','Dimi',40000,3);
                        INSERT INTO zaposleni VALUES(0,'Dimitrije','Dimi',50000,4);
                        INSERT INTO zaposleni VALUES(0,'Ivan','Anon',40000,5);
                        INSERT INTO zaposleni VALUES(0,'Ivan','Dziki',45000,6);
                        INSERT INTO zaposleni VALUES(0,'Uros','Leki',40000,7);
                        INSERT INTO zaposleni VALUES(0,'Vlasta','Vje',45000,8);
                        INSERT INTO zaposleni VALUES(0,'Milan','Dziki',45000,9);
                        INSERT INTO zaposleni VALUES(0,'Vlasta','Vje',40000,10);
                        INSERT INTO zaposleni VALUES(0,'Srdjan','vajagic',50000,11);
                        INSERT INTO zaposleni VALUES(0,'Dimitrije','Anon',44000,12);
                        INSERT INTO zaposleni VALUES(0,'Igor','bajat',40000,13);
                        INSERT INTO zaposleni VALUES(0,'Dimitrije','Dimi',44000,14);
                        INSERT INTO zaposleni VALUES(0,'Ivan','vajagic',40000,15);
                        INSERT INTO zaposleni VALUES(0,'Uros','Leki',40000,16);
                        INSERT INTO zaposleni VALUES(0,'Vlasta','vajagic',49000,17);
                        INSERT INTO zaposleni VALUES(0,'Marko','Bajat',48000,18);
                        INSERT INTO zaposleni VALUES(0,'Milan','Meh',42000,19);
                        INSERT INTO zaposleni VALUES(0,'Srdjan','Miki',43000,20);", databaseConnection);
            tables.ExecuteNonQuery();
            databaseConnection.Close();
            Console.WriteLine("Gotovo");
            Console.ReadLine();
        }

        public void popuniTabelePlocice()
        {
            string MySqlConnectionString = "datasource=localhost;port=3306;username=root;database=keramikavjestica";
            MySqlConnection databaseConnection = new MySqlConnection(MySqlConnectionString);
            databaseConnection.Open();
            MySqlCommand tables = new MySqlCommand(@"
                        INSERT INTO plocice VALUES(0,'Azur1','Zidna',1200);
                        INSERT INTO plocice VALUES(0,'Azur2','Zidna',1200);
                        INSERT INTO plocice VALUES(0,'Azu3','Podna',1200);
                        INSERT INTO plocice VALUES(0,'Azur4','Zidna',1200);
                        INSERT INTO plocice VALUES(0,'Azur5','Podna',1200);
                        INSERT INTO plocice VALUES(0,'Violet1','Podna',1400);
                        INSERT INTO plocice VALUES(0,'Violet2','Zidna',1200);
                        INSERT INTO plocice VALUES(0,'Violet3','Zidna',1400);
                        INSERT INTO plocice VALUES(0,'Violet4','Podna',1200);
                        INSERT INTO plocice VALUES(0,'Violet5','Zidna',1600);
                        INSERT INTO plocice VALUES(0,'Plaha1','Podna',3200);
                        INSERT INTO plocice VALUES(0,'Plaha2','Zidna',1350);
                        INSERT INTO plocice VALUES(0,'Plaha3','Podna',1220);
                        INSERT INTO plocice VALUES(0,'Plaha4','Zidna',1200);
                        INSERT INTO plocice VALUES(0,'Plaha5','Podna',1660);
                        INSERT INTO plocice VALUES(0,'Dark1','podna',3200);
                        INSERT INTO plocice VALUES(0,'Dark2','Zidna',4200);
                        INSERT INTO plocice VALUES(0,'Dark3','Zidna',2250);
                        INSERT INTO plocice VALUES(0,'Dark4','Zidna',3440);
                        INSERT INTO plocice VALUES(0,'Dark5','podna',5340);
                        ", databaseConnection);
            tables.ExecuteNonQuery();
            databaseConnection.Close();
            Console.WriteLine("Gotovo");
            Console.ReadLine();
        }

        public void popuniTabeleBaterije()
        {
            string MySqlConnectionString = "datasource=localhost;port=3306;username=root;database=keramikavjestica";
            MySqlConnection databaseConnection = new MySqlConnection(MySqlConnectionString);
            databaseConnection.Open();
            MySqlCommand tables = new MySqlCommand(@"
                        INSERT INTO baterije VALUES(0,'Klasik1','Tus',5200);
                        INSERT INTO baterije VALUES(0,'Klasik2','Lavabo',6200);
                        INSERT INTO baterije VALUES(0,'Klasik3','Tus',7000);
                        INSERT INTO baterije VALUES(0,'Klasik4','Tus',5150);
                        INSERT INTO baterije VALUES(0,'Klasik5','Lavabo',4200);
                        INSERT INTO baterije VALUES(0,'EcoLine1','Tus',1400);
                        INSERT INTO baterije VALUES(0,'EcoLine2','Lavabo',3600);
                        INSERT INTO baterije VALUES(0,'EcoLine3','Tus',4407);
                        INSERT INTO baterije VALUES(0,'EcoLine4','Lavabo',5206);
                        INSERT INTO baterije VALUES(0,'EcoLine5','Tus',1608);
                        INSERT INTO baterije VALUES(0,'Perla1','Lavabo',16200);
                        INSERT INTO baterije VALUES(0,'Perla2','Tus',1350);
                        INSERT INTO baterije VALUES(0,'Perla3','Tus',14000);
                        INSERT INTO baterije VALUES(0,'Perla4','Tus',1200);
                        INSERT INTO baterije VALUES(0,'Perla5','Lavabo',2660);
                        INSERT INTO baterije VALUES(0,'DarkLina1','Lavabo',7200);
                        INSERT INTO baterije VALUES(0,'DarkLina2','Tus',8900);
                        INSERT INTO baterije VALUES(0,'DarkLina3','Lavabo',5250);
                        INSERT INTO baterije VALUES(0,'DarkLina4','Tus',7440);
                        INSERT INTO baterije VALUES(0,'DarkLina5','Tus',3340);
                        ", databaseConnection);
            tables.ExecuteNonQuery();
            databaseConnection.Close();
            Console.WriteLine("Gotovo");
            Console.ReadLine();
        }

        public void popuniTabeleSaradnici()
        {
            string MySqlConnectionString = "datasource=localhost;port=3306;username=root;database=keramikavjestica";
            MySqlConnection databaseConnection = new MySqlConnection(MySqlConnectionString);
            databaseConnection.Open();
            MySqlCommand tables = new MySqlCommand(@"
                        INSERT INTO saradnici VALUES(0,'Milan','Vaja','Majstor',5000);
                        INSERT INTO saradnici VALUES(0,'Stefan','Miki','Arhitekta',6000);
                        INSERT INTO saradnici VALUES(0,'Milan','Vaja','Majstor',7000);
                        INSERT INTO saradnici VALUES(0,'Stefan','Plavsic','Arhitekta',8000);
                        INSERT INTO saradnici VALUES(0,'Milan','Miki','Majstor',9000);
                        INSERT INTO saradnici VALUES(0,'Stefan','Vaja','Arhitekta',10000);
                        INSERT INTO saradnici VALUES(0,'Milan','Gasic','Majstor',11000);
                        INSERT INTO saradnici VALUES(0,'Vuk','Plavsic','Arhitekta',5000);
                        INSERT INTO saradnici VALUES(0,'Igor','Liki','Majstor',6000);
                        INSERT INTO saradnici VALUES(0,'Milan','Gasic','Arhitekta',5000);
                        INSERT INTO saradnici VALUES(0,'Igor','Vaja','Majstor',5000);
                        INSERT INTO saradnici VALUES(0,'Milan','Gasic','Arhitekta',7000);
                        INSERT INTO saradnici VALUES(0,'Igor','Vjes','Majstor',5000);
                        INSERT INTO saradnici VALUES(0,'Vuk','Plavsic','Arhitekta',5000);
                        INSERT INTO saradnici VALUES(0,'Milan','Vesko','Majstor',3000);
                        INSERT INTO saradnici VALUES(0,'Igor','Miki','Arhitekta',5000);
                        INSERT INTO saradnici VALUES(0,'Stefan','Vjes','Majstor',2000);
                        INSERT INTO saradnici VALUES(0,'Vuk','Plavsic','Arhitekta',2000);
                        INSERT INTO saradnici VALUES(0,'Milan','Liki','Majstor',1000);
                        INSERT INTO saradnici VALUES(0,'Vuk','Vjes','Arhitekta',1000);
                        ", databaseConnection);
            tables.ExecuteNonQuery();
            databaseConnection.Close();
            Console.WriteLine("Gotovo");
            Console.ReadLine();
        }

        public void popuniTabeleKupciNaug()
        {
            string MySqlConnectionString = "datasource=localhost;port=3306;username=root;database=keramikavjestica";
            MySqlConnection databaseConnection = new MySqlConnection(MySqlConnectionString);
            databaseConnection.Open();
            MySqlCommand tables = new MySqlCommand(@"
                        INSERT INTO kupcinaugovor VALUES(0,'Impex',100000,'Backa Palanka');
                        INSERT INTO kupcinaugovor VALUES(0,'Impex1',200000,'Novi Sad');
                        INSERT INTO kupcinaugovor VALUES(0,'Impex3',300000,'Beograd');
                        INSERT INTO kupcinaugovor VALUES(0,'Impex4',400000,'Novi Sad');
                        INSERT INTO kupcinaugovor VALUES(0,'Lakigradnja4',500000,'Beograd');
                        INSERT INTO kupcinaugovor VALUES(0,'GradnjaAn',155000,'Kula');
                        INSERT INTO kupcinaugovor VALUES(0,'GradnjaAn',234000,'Novi Sad');
                        INSERT INTO kupcinaugovor VALUES(0,'Fontana',100450,'Subotica');
                        INSERT INTO kupcinaugovor VALUES(0,'Impex',134500,'Beograd');
                        INSERT INTO kupcinaugovor VALUES(0,'Fontana',432500,'Subotica');
                        INSERT INTO kupcinaugovor VALUES(0,'Impex6',765000,'Subotica');
                        INSERT INTO kupcinaugovor VALUES(0,'Impex5',325000,'Novi Sad');
                        INSERT INTO kupcinaugovor VALUES(0,'GradnjaAn',355000,'Kula');
                        INSERT INTO kupcinaugovor VALUES(0,'Lakigradnja3',1006540,'Beograd');
                        INSERT INTO kupcinaugovor VALUES(0,'Fontana',1005430,'Subotica');
                        INSERT INTO kupcinaugovor VALUES(0,'Impex7',10330,'Novi Sad');
                        INSERT INTO kupcinaugovor VALUES(0,'Impex8',1250000,'Kula');
                        INSERT INTO kupcinaugovor VALUES(0,'Lakigradnja2',250000,'Beograd');
                        INSERT INTO kupcinaugovor VALUES(0,'GradnjaAn',460000,'Backa Palanka');
                        INSERT INTO kupcinaugovor VALUES(0,'Lakigradnja1',588000,'Beograd');
                        
                        ", databaseConnection);
            tables.ExecuteNonQuery();
            databaseConnection.Close();
            Console.WriteLine("Gotovo");
            Console.ReadLine();
        }

        public void popuniTabeleDuznici()
        {
            string MySqlConnectionString = "datasource=localhost;port=3306;username=root;database=keramikavjestica";
            MySqlConnection databaseConnection = new MySqlConnection(MySqlConnectionString);
            databaseConnection.Open();
            MySqlCommand tables = new MySqlCommand(@"
                        INSERT INTO duznici VALUES(0,'Milos','Viki',15000,30);
                        INSERT INTO duznici VALUES(0,'Vuk','Vujic',15000,20);
                        INSERT INTO duznici VALUES(0,'Nemanja','Vujic',20000,30);
                        INSERT INTO duznici VALUES(0,'Stovla','Saki',20000,10);
                        INSERT INTO duznici VALUES(0,'Milos','Milosevic',15000,20);
                        INSERT INTO duznici VALUES(0,'Nemanja','Vujic',25000,30);
                        INSERT INTO duznici VALUES(0,'Stovla','Saki',12000,30);
                        INSERT INTO duznici VALUES(0,'Stovla','Vucic',35000,40);
                        INSERT INTO duznici VALUES(0,'Milos','Milosevic',15000,40);
                        INSERT INTO duznici VALUES(0,'Milos','Milosevic',14500,30);
                        INSERT INTO duznici VALUES(0,'Nemanja','Viki',12700,60);
                        INSERT INTO duznici VALUES(0,'Milos','Viki',15000,60);
                        INSERT INTO duznici VALUES(0,'Igor','Vucic',31000,60);
                        INSERT INTO duznici VALUES(0,'Vaso','Vjes',32000,60);
                        INSERT INTO duznici VALUES(0,'Igor','Saki',33440,70);
                        INSERT INTO duznici VALUES(0,'Igor','Vucic',18880,70);
                        INSERT INTO duznici VALUES(0,'Stovla','Viki',16660,80);
                        INSERT INTO duznici VALUES(0,'Vaso','Viki',29000,80);
                        INSERT INTO duznici VALUES(0,'Igor','Saki',310450,90);
                        INSERT INTO duznici VALUES(0,'Vaso','Vjes',35000,100);
                        
                        
                        ", databaseConnection);
            tables.ExecuteNonQuery();
            databaseConnection.Close();
            Console.WriteLine("Gotovo");
            Console.ReadLine();
        }

        public void popuniTabeleVozila()
        {
            string MySqlConnectionString = "datasource=localhost;port=3306;username=root;database=keramikavjestica";
            MySqlConnection databaseConnection = new MySqlConnection(MySqlConnectionString);
            databaseConnection.Open();
            MySqlCommand tables = new MySqlCommand(@"
                        INSERT INTO vozila VALUES(0,'TA133',1,20,20,50000);
                        INSERT INTO vozila VALUES(0,'TA1453',2,19,30,50000);
                        INSERT INTO vozila VALUES(0,'TA1765',3,18,30,50000);
                        INSERT INTO vozila VALUES(0,'TA134',4,17,20,50000);
                        INSERT INTO vozila VALUES(0,'TA1387',5,16,21,50000);
                        INSERT INTO vozila VALUES(0,'OT1323',6,15,23,60000);
                        INSERT INTO vozila VALUES(0,'TA443',7,14,24,60000);
                        INSERT INTO vozila VALUES(0,'TI553',8,13,54,60000);
                        INSERT INTO vozila VALUES(0,'TI187',9,12,33,60000);
                        INSERT INTO vozila VALUES(0,'TN1876',10,11,41,70000);
                        INSERT INTO vozila VALUES(0,'TN1876',11,10,40,70000);
                        INSERT INTO vozila VALUES(0,'TN1876',12,9,40,70000);
                        INSERT INTO vozila VALUES(0,'TM1678',13,8,34,80000);
                        INSERT INTO vozila VALUES(0,'TM6783',14,7,34,80000);
                        INSERT INTO vozila VALUES(0,'TM333',15,6,35,80000);
                        INSERT INTO vozila VALUES(0,'TM15433',16,5,36,12000);
                        INSERT INTO vozila VALUES(0,'TL1765',17,4,62,123000);
                        INSERT INTO vozila VALUES(0,'TL7653',18,3,60,144000);
                        INSERT INTO vozila VALUES(0,'TO763',19,2,71,55000);
                        INSERT INTO vozila VALUES(0,'TO553',20,1,38,400000);

                        ", databaseConnection);
            tables.ExecuteNonQuery();
            databaseConnection.Close();
            Console.WriteLine("Gotovo");
            Console.ReadLine();
        }

        public void popuniTabelePorudzbenice()
        {
            string MySqlConnectionString = "datasource=localhost;port=3306;username=root;database=keramikavjestica";
            MySqlConnection databaseConnection = new MySqlConnection(MySqlConnectionString);
            databaseConnection.Open();
            MySqlCommand tables = new MySqlCommand(@"
                        INSERT INTO porudzbenice VALUES(0,12060,1,1,1);
                        INSERT INTO porudzbenice VALUES(0,14600,2,2,2);
                        INSERT INTO porudzbenice VALUES(0,52060,3,3,2);
                        INSERT INTO porudzbenice VALUES(0,32400,4,4,4);
                        INSERT INTO porudzbenice VALUES(0,12000,5,3,5);
                        INSERT INTO porudzbenice VALUES(0,12270,6,6,6);
                        INSERT INTO porudzbenice VALUES(0,2200,7,7,7);
                        INSERT INTO porudzbenice VALUES(0,1440,8,5,8);
                        INSERT INTO porudzbenice VALUES(0,444000,9,9,9);
                        INSERT INTO porudzbenice VALUES(0,15600,10,12,2);
                        INSERT INTO porudzbenice VALUES(0,145600,11,1,11);
                        INSERT INTO porudzbenice VALUES(0,12300,12,12,12);
                        INSERT INTO porudzbenice VALUES(0,124500,13,13,13);
                        INSERT INTO porudzbenice VALUES(0,72980,14,4,1);
                        INSERT INTO porudzbenice VALUES(0,12700,15,15,15);
                        INSERT INTO porudzbenice VALUES(0,62500,16,14,1);
                        INSERT INTO porudzbenice VALUES(0,52800,17,1,18);
                        INSERT INTO porudzbenice VALUES(0,52080,18,13,1);
                        INSERT INTO porudzbenice VALUES(0,12080,19,1,17);
                        INSERT INTO porudzbenice VALUES(0,32700,20,1,1);
                        

                        ", databaseConnection);
            tables.ExecuteNonQuery();
            databaseConnection.Close();
            Console.WriteLine("Gotovo");
            Console.ReadLine();
        }

        public void popuniTabeleDobavljaci()
        {
            string MySqlConnectionString = "datasource=localhost;port=3306;username=root;database=keramikavjestica";
            MySqlConnection databaseConnection = new MySqlConnection(MySqlConnectionString);
            databaseConnection.Open();
            MySqlCommand tables = new MySqlCommand(@"
                        INSERT INTO dobavljaci VALUES(0,'Ornament','Novi Sad',1500000,30000);
                        INSERT INTO dobavljaci VALUES(0,'Ornament2','Sabac',2200000,0);
                        INSERT INTO dobavljaci VALUES(0,'Ornament3','Sabac',100000,20010);
                        INSERT INTO dobavljaci VALUES(0,'Ornament4','Beograd',200000,0);
                        INSERT INTO dobavljaci VALUES(0,'Ornament5','Novi Sad',12555000,20000);
                        INSERT INTO dobavljaci VALUES(0,'Zorka1','Subotica',1440660,0);
                        INSERT INTO dobavljaci VALUES(0,'Zorka2','Novi Sad',1660000,20000);
                        INSERT INTO dobavljaci VALUES(0,'Zorka3','Subotica',365400,0);
                        INSERT INTO dobavljaci VALUES(0,'Zorka4','Subotica',2500000,20000);
                        INSERT INTO dobavljaci VALUES(0,'Zorka5','Beograd',4500000,20000);
                        INSERT INTO dobavljaci VALUES(0,'Merkur1','Novi Sad',5600000,0);
                        INSERT INTO dobavljaci VALUES(0,'Merkur2','Sabac',800000,0);
                        INSERT INTO dobavljaci VALUES(0,'Merkur3','Beograd',950000,46000);
                        INSERT INTO dobavljaci VALUES(0,'Merkur4','Sabac',900000,86700);
                        INSERT INTO dobavljaci VALUES(0,'Merkur5','Novi Sad',8900000,28700);
                        INSERT INTO dobavljaci VALUES(0,'Keramika Kanjiza1','Subotica',1300000,4500);
                        INSERT INTO dobavljaci VALUES(0,'Keramika Kanjiza2','Beograd',8700000,5600);
                        INSERT INTO dobavljaci VALUES(0,'Keramika Kanjiza3','Sabac',1974500,3300);
                        INSERT INTO dobavljaci VALUES(0,'Keramika Kanjiza4','Beograd',5660304,0);
                        INSERT INTO dobavljaci VALUES(0,'Keramika Kanjiza5','Novi Sad',7400461,0);
                        
                        

                        ", databaseConnection);
            tables.ExecuteNonQuery();
            databaseConnection.Close();
            Console.WriteLine("Gotovo");
            Console.ReadLine();
        }




    }
}

