using System;
using System.Collections.Generic;
using System.Text;

namespace GM5_Campaign
{
    class Note
    {
        public string Title
        {
            get => note.title ?? "";
            set => note.title = value;
        }

        public string Text
        {
            get => note.text ?? "";
            set => note.text = value;
        }

        public Schemas.campaignNote NoteEntity => note;

        private Schemas.campaignNote note = new Schemas.campaignNote();
    }
}
