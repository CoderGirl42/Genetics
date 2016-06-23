using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genetics
{
    public class Gene
    {
        private int _gene;
        private int _geneLength;
        public bool CrossPoint { get; private set; }
        public bool Mutation { get; private set; }

        private static Random _random = new Random((int)DateTime.Now.Ticks);

        public int GeneLength {
            get { return _geneLength; }
        }

        public void SetCrossPoint() {
            CrossPoint = true;
        }

        public void SetMutation() {
            Mutation = true;
        }

        public Gene(int length) {
            _gene = 0;
            _geneLength = length;
            CrossPoint = false;
            Mutation = false;
        }

        public void SetGene(int locus) {
            int mask = 1 << locus;
            _gene |= mask;
        }

        public bool IsSet(int locus) {
            return (_gene & (1 << locus)) != 0;
        }

        public override string ToString() {
            return Convert.ToString(_gene, 2).PadLeft(_geneLength, '0');
        }

        public void Copy(Gene parent) {
            _gene = parent._gene;
        }

        public static Gene RandomGene(int length) {
            Gene gene = new Gene(length);

            int locas = _random.Next(0, length);

            gene.SetGene(locas);

            return gene;
        }
    }
}
