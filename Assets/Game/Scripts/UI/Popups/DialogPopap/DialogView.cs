using Game.Scripts.UI.MVVM;
using R3;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.UI.Popups.DialogPopap
{
    public class DialogView : View<DialogViewModel>
    {
        [SerializeField] private TextMeshProUGUI _textField;
        [SerializeField] private TextMeshProUGUI _speakerName;
        [SerializeField] private Button _nextButton;
        [SerializeField] private DialogChoiceView _dialogChoiceView;

        private CompositeDisposable _compositeDisposable = new CompositeDisposable();

        protected override void OnBindViewModel()
        {
            _dialogChoiceView.Init(ViewModel);

            _compositeDisposable.Add(ViewModel.CurrentSpeakerName
                .Subscribe(name => _speakerName.text = name));
            _compositeDisposable.Add(ViewModel.CurrentDialogText
                .Subscribe(text =>  _textField.text = text));
            
            _compositeDisposable.Add(ViewModel.ChoiceIsActive.Where(f => f == true)
                .Subscribe(f => ChangeUiForStartChoice()));
            _compositeDisposable.Add(ViewModel.ChoiceIsActive.Where(f => f == false)
                .Subscribe(f => ChangeUiForEndChoice()));
            
            _nextButton.onClick.AddListener(NextButtonClicked);
        }

        private void Start()
        {
            // _dialogChoiceView.Init(ViewModel);
            //
            // _compositeDisposable.Add(ViewModel.CurrentSpeakerName
            //     .Subscribe(name => _speakerName.text = name));
            // _compositeDisposable.Add(ViewModel.CurrentDialogText
            //     .Subscribe(text =>  _textField.text = text));
            //
            // _compositeDisposable.Add(ViewModel.ChoiceIsActive.Where(f => f == true)
            //     .Subscribe(f => ChangeUiForStartChoice()));
            // _compositeDisposable.Add(ViewModel.ChoiceIsActive.Where(f => f == false)
            //     .Subscribe(f => ChangeUiForEndChoice()));
            //
            // _nextButton.onClick.AddListener(NextButtonClicked);
        }

        private void NextButtonClicked()
        {
            ViewModel.NextDialog();
        }

        private void ChangeUiForStartChoice()
        {
            _nextButton.gameObject.SetActive(false);
            _dialogChoiceView.BuildChoiceView();
        }
        
        private void ChangeUiForEndChoice()
        {
            _nextButton.gameObject.SetActive(true);
            _dialogChoiceView.DestroyChoiceView();
        }

        protected override void OnUnBindViewModel()
        {
            _compositeDisposable.Dispose();
            Destroy(gameObject);
        }
    }
}