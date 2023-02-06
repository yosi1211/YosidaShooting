using System.Collections.Generic;
using UnityEngine;

namespace PoolControler_SearchR
{
    public class ObjectPoolControler_SearchR : MonoBehaviour
    {
        //Player‚Ìæ“¾
        [SerializeField] private GameObject player;
        List<BulletController_SearchR> _SearchR;
        int listCount = 0;
        //’e‚ÌƒvƒŒƒnƒu
        [SerializeField] BulletController_SearchR bullet;
        [SerializeField] Transform bulletPrefab;
        //¶¬‚·‚é”
        [SerializeField] int maxCount;
        //¶¬‚µ‚½’e‚ğŠi”[‚·‚éQueue
        Queue<BulletController_SearchR> bulletQueue;
        //‰‰ñ¶¬‚Ìƒ|ƒWƒVƒ‡ƒ“
        Vector3 setPos = new Vector3(100, 100, 0);
        Quaternion setRot = Quaternion.identity;
        int density = 10;
        int z = 0;

        //‹N“®‚Ìˆ—
        private void Awake()
        {
            //Queue‚Ì‰Šú‰»
            bulletQueue = new Queue<BulletController_SearchR>();
            _SearchR = new List<BulletController_SearchR>();
            listCount = _SearchR.Count;
            //’e‚ğ¶¬‚·‚éƒ‹[ƒv
            for (int i = 0; i < maxCount; i++)
            {
                //¶¬
                BulletController_SearchR tmpBullet = Instantiate(bullet, setPos, setRot, transform);
                tmpBullet.Init(player);
                //Queue‚É’Ç‰Á
                bulletQueue.Enqueue(tmpBullet);
            }
        }


        //’e‚ğ‘İ‚µo‚·ˆ—
        public BulletController_SearchR Launch(Vector3 _pos)
        {
            //Queue‚ª‹ó‚È‚çnull
            if (bulletQueue.Count <= 0) return null;
            //Queue‚©‚ç’e‚ğˆê‚Âæ‚èo‚·
            BulletController_SearchR tmpBullet = bulletQueue.Dequeue();
            //’e‚ğ•\¦‚·‚é
            tmpBullet.gameObject.SetActive(true);
            _SearchR.Add(tmpBullet);
            //“n‚³‚ê‚½À•W‚É’e‚ğˆÚ“®‚·‚é
            tmpBullet.ShowInStage(_pos);
            tmpBullet.transform.position += Vector3.right;
            //ŒÄ‚Ño‚µŒ³‚É“n‚·
            return tmpBullet;
        }

        //’e‚Ì‰ñûˆ—
        public void Collect(BulletController_SearchR _bullet)
        {
            //’e‚ÌƒQ[ƒ€ƒIƒuƒWƒFƒNƒg‚ğ”ñ•\¦
            _bullet.gameObject.SetActive(false);
            //Queue‚ÉŠi”[
            bulletQueue.Enqueue(_bullet);
        }
        public void CollectList()
        {
            listCount = _SearchR.Count;
            for (int i = 0; i < listCount; i++)
            {
                Collect(_SearchR[i]);
            }
            _SearchR.Clear();
        }
        public int Getdensity()
        {
            return density;
        }

    }
}
