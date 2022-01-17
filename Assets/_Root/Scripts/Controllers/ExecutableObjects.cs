﻿using System;
using System.Collections.Generic;
using _Root.Scripts.Controllers.Interfaces;

namespace _Root.Scripts.Controllers
{
    public class ExecutableObjects : IExecutable
    {
        private List<IExecutable> _executables = new List<IExecutable>();
        
        public void Execute(float deltaTime)
        {
            for (int i = 0; i < _executables.Count; i++)
            {
                _executables[i].Execute(deltaTime);
            }
        }

        public void AddExecutable(IExecutable executable)
        {
            _executables.Add(executable);
        }

        public void RemoveExecutable(IExecutable executable)
        {
            _executables.Remove(executable);
        }
        
    }
}