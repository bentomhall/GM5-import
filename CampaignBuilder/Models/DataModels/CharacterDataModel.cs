using System;
using CampaignCore;

namespace CampaignBuilder.Models.DataModels
{
    public class CharacterDataModel
    {
        public CharacterDataModel(Character character, CharacterType role)
        {
            mCharacter = character;
            mRole = role;
        }

        public string Name
        {
            get { return mCharacter.Name; }
            set { mCharacter.Name = value; }
        }

        private Character mCharacter;
        private CharacterType mRole;
    }
}
