using System;
using System.Collections.Generic;
using Zenject;
using IState = Game.Scripts.Interfaces.IState;

namespace Game.Scripts.GameStates
{
    public class GameStateMachine : IInitializable
    {
        private IState _currentState;
        private Dictionary<Type, IState> _states;
        
        private readonly DiContainer _container;

        public GameStateMachine(DiContainer container)
        {
            _container = container;
        }

        public void Initialize()
        {
            _states = new Dictionary<Type, IState>()
            {
                {typeof(BootstrapState), _container.Resolve<BootstrapState>()},
                {typeof(ShowStartMenuState), _container.Resolve<ShowStartMenuState>()},
                {typeof(LevelSelectState), _container.Resolve<LevelSelectState>()},
                {typeof(GameLoopState), _container.Resolve<GameLoopState>()},
            };
            
            Enter<BootstrapState>();
        }

        public void Enter<TState>() where TState : IState
        {
            IState state = _states[typeof(TState)];
            _currentState?.Exit();
            _currentState = state;
            _currentState?.Enter();
        }
    }
}