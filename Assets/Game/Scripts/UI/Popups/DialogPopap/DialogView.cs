using Game.Scripts.UI.MVVM;
using Game.Scripts.UI.Popups.DialogPopap.DialogViewElements;
using R3;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Game.Scripts.UI.Popups.DialogPopap
{
    public class DialogView : View<DialogViewModel>
    {
        [SerializeField] private TextMeshProUGUI _textField;
        [SerializeField] private TextMeshProUGUI _speakerName;
        [SerializeField] private Button _nextButton;
        [SerializeField] private DialogChoiceView _choiceView;
        [SerializeField] private DialogImageView _imageView;

        private CompositeDisposable _compositeDisposable = new CompositeDisposable();

        private void Start()
        {
            _choiceView.Init(ViewModel);
            _imageView.Init(ViewModel);

            _compositeDisposable.Add(ViewModel.CurrentSpeakerName
                .Subscribe(name => _speakerName.text = name));
            _compositeDisposable.Add(ViewModel.CurrentDialogText
                .Subscribe(text =>  _textField.text = " - " + text));
            
            _compositeDisposable.Add(ViewModel.ChoiceIsActive.Where(f => f == true)
                .Subscribe(f => ChangeUiForStartChoice()));
            _compositeDisposable.Add(ViewModel.ChoiceIsActive.Where(f => f == false)
                .Subscribe(f => ChangeUiForEndChoice()));
            
            _nextButton.onClick.AddListener(NextButtonClicked);
        }

        private void NextButtonClicked()
        {
            ViewModel.NextDialog();
        }

        private void ChangeUiForStartChoice()
        {
            _nextButton.gameObject.SetActive(false);
            _choiceView.BuildChoiceView();
        }
        
        private void ChangeUiForEndChoice()
        {
            _nextButton.gameObject.SetActive(true);
            _choiceView.DestroyChoiceView();
        }

        protected override void OnUnBindViewModel()
        {
            _compositeDisposable.Dispose();
            _choiceView.OnUnBindViewModel();
            _imageView.OnUnBindViewModel();
            Destroy(gameObject);
        }
    }
}