using UnityEngine;
using TMPro;
namespace RuslanScripts
{
    public class BusName_UI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _nameText;

        public void SetName(string name)
        {
            _nameText.text = name;
        }
    }


}