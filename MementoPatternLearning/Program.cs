using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MementoPatternLearning
{
    class Program
    {
        static void Main(string[] args)
        {
            Hero hero = new Hero();
            hero.ShowStats();
            hero.CastFireball();
            GameHistory game = new GameHistory();

            game.History.Push(hero.SaveState()); 

            hero.CastFireball(); 

            hero.RestoreState(game.History.Pop());

            hero.CastFireball(); 

            Console.Read();
        }
    }

    // Originator
    class Hero
    {
        private int _mana = 25;
        private int _health = 10; 
        private int _spellCost = 5;

        public void CastFireball()
        {
            if (_mana > 0)
            {
                _mana = _mana - _spellCost;
                Console.WriteLine($"Using fireball. Remain mana {_mana}\n");
            }
            else
                Console.WriteLine("No mana");
        }
        // saving state
        public HeroMemento SaveState()
        {
            Console.WriteLine("Saving game...");
            ShowStats();
            return new HeroMemento(_mana, _health);
        }

        // restoring state
        public void RestoreState(HeroMemento memento)
        {
            this._mana = memento.Mana;
            this._health = memento.Health;
            Console.WriteLine("Loading game...");
            ShowStats();
        }
        public void ShowStats()
        {
            Console.WriteLine($"Hero stats| Health: {_health}| Mana: {_mana}\n");
        }
    }
    // Memento
    class HeroMemento
    {
        public int Mana { get; private set; }
        public int Health { get; private set; }

        public HeroMemento(int mana, int health)
        {
            this.Mana = mana;
            this.Health = health;
        }
    }

    // Caretaker
    class GameHistory
    {
        public Stack<HeroMemento> History { get; private set; }
        public GameHistory()
        {
            History = new Stack<HeroMemento>();
        }
    }

}

