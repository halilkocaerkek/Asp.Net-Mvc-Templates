using DataModel;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Repository.Initializer
{
    public class ddsportInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ddsport>
    {
        protected override void Seed ( ddsport context )
        {
            UnitOfWork db = new UnitOfWork();

            #region document types
            var kimlik = new documenttype { id = 1, name = "Kimlik", pageCount = 2 };
            var saglikRaporu = new documenttype { id = 2, name = "Sağlık Raporu", pageCount = 1 };
            var Vize = new documenttype { id = 3, name = "Antrönör Vizesi", pageCount = 1 };
            var diploma = new documenttype { id = 4, name = "Diploma", pageCount = 1 };

            context.documenttype.Add(kimlik);
            context.documenttype.Add(saglikRaporu);
            context.documenttype.Add(Vize);
            context.documenttype.Add(diploma);
            context.SaveChanges();
            #endregion;

            #region measures
            var kilo = new measuretype {id=1, Name = "Kilo", unit = "gr", minvalue=0, maxvalue=200 };
            var boy = new measuretype {id=2,Name = "Boy", unit = "cm", minvalue=0, maxvalue=220 };
            context.measuretype.Add(kilo);
            context.measuretype.Add(boy);
            context.SaveChanges( );
            #endregion

            #region Add belt Colors.
            var Beyaz =  new beltColor { name = "Beyaz" , value = ColorTranslator.ToHtml(Color.White) };
            var Sarı =  new beltColor { name = "Sarı" , value = ColorTranslator.ToHtml(Color.Yellow)  };
            var Kahverengi =  new beltColor { name = "Kahverengi" , value =ColorTranslator.ToHtml(Color.Brown)  };
            var Siyah =  new beltColor { name = "Siyah" , value = ColorTranslator.ToHtml(Color.Black)  };

            var beltColors = new List<beltColor>{Beyaz, Sarı , Kahverengi,Siyah  };
            beltColors.ForEach(bc => context.BeltColor.Add(bc));
            context.SaveChanges( );
            #endregion

            #region add sport branches
            var Teakwando = new branch{name="Teakwando"};
            var Aikido = new branch{name="Aikido"};
            var Karete = new branch{name="Karete"};

            var branchs = new List<branch>
            {Teakwando,Aikido,Karete };

            branchs.ForEach(b => context.Branch.Add(b));
            context.SaveChanges( );
            #endregion

            #region add belts to teakwando.
            var BeyazKusak = new belt {name="Beyaz", order=1, branch=Teakwando,beltColor=Beyaz };
            var SarıKusak = new belt {name="Sarı", order=1, branch=Teakwando,beltColor=Sarı };
            var KahverengiKusak = new belt {name="Kahverengi", order=1, branch=Teakwando,beltColor=Kahverengi };
            var SiyahKusak = new belt {name="Siyah", order=1, branch=Teakwando,beltColor=Siyah };

            var belts = new List<belt>
            { BeyazKusak,SarıKusak,KahverengiKusak,SiyahKusak
            };
            belts.ForEach(b => context.belt.Add(b));
            #endregion

            #region Add Schools

            var CengelkoyTeakwando = new school {name = "Çengelköy Teakwando Spor Okulu" } ;
            var UskudarTeakwando = new school {name = "Üsküdar Teakwando Spor Okulu" } ;

            var schools = new List<school>
            {
                CengelkoyTeakwando,
                UskudarTeakwando,
                new school {name="School 3" },
                new school {name="School 4" },
                new school {name="School 5" },
                new school {name="School 6" },
                new school {name="School 7" },
                new school {name="School 8" },
                new school {name="School 9" },
                new school {name="School 10" },
            };

            schools.ForEach(s => context.school.Add(s));
            context.SaveChanges( );
            #endregion

            #region Add Class to CengelkoyTeakwando

            var minikler = new sinif {name = "Minikler" ,school = CengelkoyTeakwando };
            var yildizlar = new sinif {name = "Yıldızlar",school = CengelkoyTeakwando  };
            var buyukler = new sinif {name = "Büyükler",school = CengelkoyTeakwando  };

            var cengelkoysiniflar = new List<sinif>{ minikler, yildizlar, buyukler };
            cengelkoysiniflar.ForEach(s => context.sinif.Add(s));
            context.SaveChanges( );

            #endregion

            #region Add Class to UskudarTeakwando

            minikler = new sinif { name = "Minikler" , school = UskudarTeakwando };
            yildizlar = new sinif { name = "Yıldızlar" , school = UskudarTeakwando };
            buyukler = new sinif { name = "Büyükler" , school = UskudarTeakwando };

            var uskudarSiniflar = new List<sinif>{ minikler, yildizlar, buyukler };
            uskudarSiniflar.ForEach(s => context.sinif.Add(s));
            context.SaveChanges( );

            #endregion

            #region Add Students to School

            var cengelkoyStudents = new List<student>();


            var users = randomuser.randomuser.get(20);
            for ( int i = 0 ; i < 10 ; i++ )
            {
                var u = users[i];
                cengelkoyStudents.Add(GetNewStudent(CengelkoyTeakwando, i, u));
            }
            cengelkoyStudents.ForEach(s => context.student.Add(s));
            context.SaveChanges( );

            var  uskudarStudents = new List<student>();
            users = randomuser.randomuser.get(10);
            for ( int i = 0 ; i < 10 ; i++ )
            {
                var u = users[i];
                cengelkoyStudents.Add(GetNewStudent(UskudarTeakwando, i, u));
            }
            uskudarStudents.ForEach(s => context.student.Add(s));
            context.SaveChanges( );
            #endregion

            #region Add students to Class

            var sinifOgrencileri = new List<classstudent> ();
            foreach ( var s in cengelkoysiniflar )
            {
                foreach ( var o in cengelkoyStudents )
                {
                    sinifOgrencileri.Add(new classstudent { sinif = s , student = o });
                }
            }

            foreach ( var s in uskudarSiniflar )
            {
                foreach ( var o in uskudarStudents )
                {
                    sinifOgrencileri.Add(new classstudent { sinif = s , student = o });
                }
            }
            sinifOgrencileri.ForEach(so => context.ClassStudent.Add(so));
            context.SaveChanges( );
            #endregion

            #region Add Teachers to School

            var cengelkoyTeachers = new List<teacher>();
            users = randomuser.randomuser.get(50);
            for ( int i = 0 ; i < 2 ; i++ )
            {
                var u = users[i];
                cengelkoyTeachers.Add(getNewTeacher(CengelkoyTeakwando, i, u)); 
                
            }
            cengelkoyTeachers.ForEach(s => context.teacher.Add(s));
            context.SaveChanges( );

            var  uskudarTeachers = new List<teacher>();
            users = randomuser.randomuser.get(50);
            for ( int i = 0 ; i < 2 ; i++ )
            {
                var u = users[i];
                uskudarTeachers.Add(getNewTeacher(UskudarTeakwando, i, u));
            }
            uskudarTeachers.ForEach(s => context.teacher.Add(s));
            context.SaveChanges( );
            #endregion

            #region Add students to Class

            var sinifOgretmenleri = new List<classteacher> ();
            foreach ( var s in cengelkoysiniflar )
            {
                foreach ( var o in cengelkoyTeachers )
                {
                    sinifOgretmenleri.Add(new classteacher { sinif = s , teacher = o });
                }
            }

            foreach ( var s in uskudarSiniflar )
            {
                foreach ( var o in uskudarTeachers )
                {
                    sinifOgretmenleri.Add(new classteacher { sinif = s , teacher = o });
                }
            }
            sinifOgretmenleri.ForEach(so => context.ClassTeacher.Add(so));
            context.SaveChanges( );
            #endregion

            #region add training rooms to the school

            var rooms = new List<room> {
                new room { name="Ana salon",school = CengelkoyTeakwando} ,
                new room { name="Çengelköy Lisesi Spor Salonu", school=CengelkoyTeakwando },
                new room { name="Ana salon",school = UskudarTeakwando} ,
                new room { name="Atatürk Lisesi Spor Salonu", school=UskudarTeakwando }
            };

            rooms.ForEach(r => context.room.Add(r));
            context.SaveChanges( );

            #endregion

            #region Add measures to student

            var measures = new List<measure> ();
            Random rnd = new Random(DateTime.Now.Millisecond);
            var valueKilo =  rnd.Next(30000) + 10000;
            var valueBoy =  rnd.Next(80) + 100;

            var measureTime = DateTime.Now.AddYears(-1);


            foreach ( var o in cengelkoyStudents )
            {
                valueKilo = rnd.Next(30000) + 30000;
                valueBoy = rnd.Next(80) + 100;

                measureTime = DateTime.Now.AddYears(-1);

                for ( int i = 0 ; i < rnd.Next(50) + 65 ; i++ )
                {
                    measures.Add(new measure { student = o , measuretype = boy , value = valueBoy , createdAt = measureTime , createdBy = cengelkoyTeachers [ 0 ].id });
                    measures.Add(new measure { student = o , measuretype = kilo , value = valueKilo , createdAt = measureTime , createdBy = cengelkoyTeachers [ 0 ].id });
                    measureTime = measureTime.AddDays(1);
                    valueKilo += rnd.Next(50) - rnd.Next(40);
                    valueBoy += rnd.Next(5) - rnd.Next(4);
                }
                measures.ForEach(m => context.measure.Add(m));
                context.SaveChanges( );
                measures = new List<measure>( );
            }

            valueKilo = rnd.Next(80) + 100;
            measureTime = DateTime.Now.AddYears(-1);

            foreach ( var o in uskudarStudents )
            {
                valueKilo = rnd.Next(30000) + 30000;
                measureTime = DateTime.Now.AddYears(-1);
                for ( int i = 0 ; i < rnd.Next(50) + 10 ; i++ )
                {
                    measures.Add(new measure { student = o , measuretype = boy , value = valueBoy , createdAt = measureTime , createdBy = uskudarTeachers [ 0 ].id });
                    measures.Add(new measure { student = o , measuretype = kilo , value = valueKilo , createdAt = measureTime , createdBy = uskudarTeachers [ 0 ].id });

                    measureTime = measureTime.AddDays(1);
                    valueKilo += rnd.Next(50) - rnd.Next(40);
                    valueBoy += rnd.Next(5) - rnd.Next(4);
                }
                measures.ForEach(m => context.measure.Add(m));
                context.SaveChanges( );
                measures = new List<measure>( );
            }

            measures.ForEach(m => context.measure.Add(m));
            context.SaveChanges( );
            #endregion

            base.Seed(context);
        }

        private static student GetNewStudent(school CengelkoyTeakwando, int i, randomuser.Result u)
        {
            return new student
            {
                name = u.name.first,
                surname = u.name.last,
                city = u.location.city,
                birthPlace = u.location.city,
                address = u.address,
                postcode = u.location.postcode,
                phone = u.phone,
                street = u.location.street,
                email = u.email,
                imageUrl = u.picture.large,
                thumbnailUrl = u.picture.thumbnail,
                state = u.location.state,
                school = CengelkoyTeakwando,
                birthDate = DateTime.Now.AddYears((10 + i) * -1)
            };
        }

        private static teacher getNewTeacher(school UskudarTeakwando, int i, randomuser.Result u)
        {
            return new teacher
            {
                name = u.name.first,
                surname = u.name.last,
                city = u.location.city,
                phone = u.phone,
                town = u.location.street,
                birthPlace = u.location.city,
                address = u.address,
                postcode = u.location.postcode,
                email = u.email,
                imageUrl = u.picture.large,
                thumbnailUrl = u.picture.thumbnail,
                state = u.location.state,
                school = UskudarTeakwando,
                tckn = "12345678",
                sgk = "123456789",
                licence = "12121233",
                mobilePhone = "123213213",
                montlySalary = 750000,
                hourlySalary = 65,
                percentSalary = 35,
                workBegin = DateTime.Now.AddMonths(i),
                workEnd = DateTime.MaxValue,
                birthDate = DateTime.Now.AddYears(20 + i)
            };
        }
    }
}
