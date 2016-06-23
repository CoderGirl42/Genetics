using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genetics
{
    public class Organism : IEnumerable
    {
        private int _age = 0;
        private int _maxAge = 0;
        private bool _alive = true;
        private Chromosome[] _chromosomes;

        public int Age {
            get { return _age; }
        }

        public bool IsAlive {
            get { return _alive; }
        }

        public Organism(Genotype[] karyotype, int maxAge) {
            _maxAge = maxAge;

            _chromosomes = new Chromosome[karyotype.Length];

            for(int i = 0; i < karyotype.Length; i++)  {
                _chromosomes[i] = new Chromosome(karyotype[i]);
            }
        }

        public void Update() {
            _age++;

            if(_maxAge == _age) {
                _alive = false;
            }
        }

        public float Fitness() {
            return 1 - (_age / _maxAge);
        }

        public Chromosome this[int i] {
            get { return _chromosomes[i]; }
            set { _chromosomes[i] = value; }
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return _chromosomes.GetEnumerator();
        }
    }
}
