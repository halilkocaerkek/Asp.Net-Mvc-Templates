using System.Collections.Generic;

namespace DataModel.Dto
{
    public class measureDTO
    {
        public int id;

        public int studentId;

        public int type;

        public int value;
    }
    public class measureListDTO
    {
        public List<measureListDTO> items;
    }

}