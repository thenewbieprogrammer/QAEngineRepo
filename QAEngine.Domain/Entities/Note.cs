using System;
using System.Collections.Generic;
using System.Text;

namespace QAEngine.Domain.Entities
{
    public class Note
    {
        public Note()
        {
            Description = new HashSet<NoteDescription>();
        }

        public string NoteId { get; set; }
        public int CustomerId { get; set; }
        public DateTime? CreatedNote { get; set; }
        public DateTime? DeletedNote { get; set; }

        public ICollection<NoteDescription> Description { get; private set; }
    }
}
