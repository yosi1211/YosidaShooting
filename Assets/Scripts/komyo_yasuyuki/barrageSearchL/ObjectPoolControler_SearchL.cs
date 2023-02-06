using System.Collections.Generic;
using UnityEngine;

namespace PoolControler_SearchL
{
    public class ObjectPoolControler_SearchL : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        List<BulletController_SearchL> _SearchL;
        int listCount = 0;
        //’e‚ÌƒvƒŒƒnƒu
        [SerializeField] BulletController_SearchL bullet;
        [SerializeField] Transform bulletPrefab;
        //¶¬‚·‚é”
        [SerializeField] int maxCount;
        //¶¬‚µ‚½’e‚ğŠi”[‚·‚éQueue
        Queue<BulletController_SearchL> bulletQueue;
        //‰‰ñ¶¬‚Ìƒ|ƒWƒVƒ‡ƒ“
        Vector3 setPos = new Vector3(100, 100, 0);
        Quaternion setRot = Quaternion.identity;
        int density = 10;
        int z = 0;
        //‹N“®‚Ìˆ—
        private void Awake()
        {
            //Queue‚Ì‰Šú‰»
            bulletQueue = new Queue<BulletController_SearchL>();
            _SearchL = new List<BulletController_SearchL>();
            listCount = _SearchL.Count;
            //’e‚ğ¶¬‚·‚éƒ‹[ƒv
            for (int i = 0; i < maxCount; i++)
            {
                //¶¬
                BulletController_SearchL tmpBullet = Instantiate(bullet, setPos, setRot, transform);
                tmpBullet.Init(player);
                //Queue‚É’Ç‰Á
                bulletQueue.Enqueue(tmpBullet);
            }
        }


        //’e‚ğ‘İ‚µo‚·ˆ—
        public BulletController_SearchL Launch(Vector3 _pos)
        {
            //Queue‚ª‹ó‚È‚çnull
            if (bulletQueue.Count <= 0) return null;
            //Queue‚©‚ç’e‚ğˆê‚Âæ‚èo‚·
            BulletController_SearchL tmpBullet = bulletQueue.Dequeue();
            //’e‚ğ•\¦‚·‚é
            tmpBullet.gameObject.SetActive(true);
            _SearchL.Add(tmpBullet);
            //“n‚³‚ê‚½À•W‚É’e‚ğˆÚ“®‚·‚é
            tmpBullet.ShowInStage(_pos);
            tmpBullet.transform.position += Vector3.left;
            //ŒÄ‚Ño‚µŒ³‚É“n‚·
            return tmpBullet;
        }

        //’e‚Ì‰ñûˆ—
        public void Collect(BulletController_SearchL _bullet)
        {
            //’e‚ÌƒQ[ƒ€ƒIƒuƒWƒFƒNƒg‚ğ”ñ•\¦
            _bullet.gameObject.SetActive(false);
            //Queue‚ÉŠi”[
            bulletQueue.Enqueue(_bullet);
        }
        public void CollectList()
        {
            listCount = _SearchL.Count;
            for (int i = 0; i < listCount; i++)
            {
                Collect(_SearchL[i]);
            }
            _SearchL.Clear();
        }
        public int Getdensity()
        {
            return density;
        }
    }
}