using System;
using CampaignCore;
namespace CampaignBuilder.Models.DataModels
{
    public class EncounterDataModel
    {
        public EncounterDataModel()
        {
            mEncounter = new Encounter();
        }

        public EncounterDataModel(Encounter existing)
        {
            mEncounter = existing;
        }

        private Encounter mEncounter;
    }
}
