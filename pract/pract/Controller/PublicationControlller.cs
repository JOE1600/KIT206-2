using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using System.Threading.Tasks;
using DBTestOnAlacritas;





namespace Controller
{
    public class PublicationController
    {
        public List<Publication> publication;




        DatabaseAdapter no = new DatabaseAdapter();
        public PublicationController()
        {

            publication = no.LoadAll();
        }


        public List<Publication> LoadAll()
        {
            return no.LoadAll();
        }




        public void Display()
        {
            publication.ForEach(Console.WriteLine);
        }
        public void LoadResearchers()
        {
            publication.ForEach(Console.WriteLine);
        }
        public Publication FilterbyName(string naam)
        {
            foreach (Publication publication in publication)
            {
                if (publication.Authors.Contains(naam))
                {
                    return publication;
                }
            }
            return null;
        }



        public Publication FilterbyLevel(string laal)
        {
            foreach (Publication publication in publication)
            {
                if (publication.Type.Equals(laal))
                {
                    return publication;
                }
            }
            return null;
        }
    }
}
