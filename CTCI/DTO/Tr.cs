using System;
using System.Collections.Generic;

namespace CTCI.Tr{
    public class TrieNode {
        private static readonly int ALPHABET_SIZE = 26;
        public TrieNode[] children = new TrieNode[ALPHABET_SIZE];

        private bool isEndOfWord;

        private static TrieNode root;
        public TrieNode(){ 
            isEndOfWord = false;
            for(int i = 0; i< ALPHABET_SIZE; i++){
                children[i] = null;
            }
        }

        public void Insert(string key){
            int level;
            int length = key.Length;
            int index;

            TrieNode pCrawl = root;

            for(level=0; level< length; level++){
                index = key[level] - 'a';
                if(pCrawl.children[index] == null){
                    pCrawl.children[index] = new TrieNode();
                }
                pCrawl = pCrawl.children[index];
            }

            pCrawl.isEndOfWord=true;
        }

        public bool Search(string key){
            int level;
            int length = key.Length;
            int index;

            TrieNode pCrawl = root;

            for(level = 0; level< length; level++){
                index = key[level] - 'a';

                if(pCrawl.children[index] == null){
                    return false;
                }

                pCrawl = pCrawl.children[index];
            }

            return (pCrawl!=null && pCrawl.isEndOfWord);
        }
    }
}