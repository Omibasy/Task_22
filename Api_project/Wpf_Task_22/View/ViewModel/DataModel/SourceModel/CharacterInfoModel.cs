
using Wpf_Task_22.Model;
using Wpf_Task_22.Model.Data;
using Wpf_Task_22.View.ViewModel.RegistrationModel;

namespace Wpf_Task_22.View.ViewModel.DataModel.SourceModel
{
    internal class CharacterInfoModel : BaseViewModel
    {

        public BoxPerson box { get; private set; }

        public CharacterInfoModel(int id)
        {

            box = PhoneBoockDataAPI.GetPersonsInfo(id);


        }
    }
}
