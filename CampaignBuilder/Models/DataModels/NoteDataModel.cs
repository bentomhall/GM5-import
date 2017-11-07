using System;
using CampaignCore;
namespace CampaignBuilder.Models.DataModels
{
    public class NoteDataModel
    {
        public NoteDataModel()
        {
            mNote = new Note();
        }

        public NoteDataModel(Note existing)
        {
            mNote = existing;
        }

        private Note mNote;
    }
}
