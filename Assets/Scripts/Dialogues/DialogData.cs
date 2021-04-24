using System;
using UnityEngine;

    [CreateAssetMenu()]
    public class DialogData : ScriptableObject
    {
        [Serializable]
        public class MonologData
        {
            public string phrase;
            public DialogPersID PersID;
            public bool isLeft => PersID == DialogPersID.__testPers1;
        }
        
        public MonologData[] monologs;
    }
