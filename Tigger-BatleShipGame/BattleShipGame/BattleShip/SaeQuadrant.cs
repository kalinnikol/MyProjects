using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public class SaeQuadrant
    {
        private State state;
        private bool hit;  // the field "hit" is needed because in the State enum there are
        // two states of hit ( TargetHit - when the ship is hit, Hit - empty quadrant is hit )

        public SaeQuadrant(bool hit = false, State state = State.Empty)
        {
            this.state = state;
            this.hit = hit;
        }

        public State State
        {
            get { return this.state; }
            set { this.state = value; }
        }

        public bool Hit
        {
            get { return this.hit; }
            set { this.hit = value; }
        }
    }
}
