using System;
using System.Collections.Generic;
using System.Text;

namespace CampaignCore
{
    public class Note : IEquatable<Note>
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

        public bool Equals(Note other)
        {
            return other.Title == Title;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) { return false; }
            var other = obj as Note;
            if (other == null) { return false; }
            return Equals(other);
        }

        public override int GetHashCode()
        {
            return Title.GetHashCode();
        }
    }
}
