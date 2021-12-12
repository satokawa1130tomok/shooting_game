// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CameraWork.cs" company="Exit Games GmbH">
//  一部：PhotonUnityネットワーキングデモ
// </copyright>
// <summary>
//  PUNの基本チュートリアルで、プレーヤーをフォローするためのカメラ作業を処理するために使用されます
// </summary>
// <author>developer@exitgames.com</author>
// --------------------------------------------------------------------------------------------------------------------

using UnityEngine;

namespace Photon.Pun.Demo.PunBasics 
{
	/// <summary>
	/// カメラワーク。 ターゲットをフォローする
	/// </summary>
	public class CameraWork : MonoBehaviour 
	{
        #region Private Fields

	    [Tooltip("The distance in the local x-z plane to the target")]
	    [SerializeField]
	    private float distance = 7.0f;
			
	    [Tooltip("The height we want the camera to be above the target")]	
	    [SerializeField]
	    private float height = 3.0f;
	    
	    [Tooltip("Allow the camera to be offseted vertically from the target, for example giving more view of the sceneray and less ground.")]
	    [SerializeField]
	    private Vector3 centerOffset = Vector3.zero;

	    [Tooltip("Set this as false if a component of a prefab being instanciated by Photon Network, and manually call OnStartFollowing() when and if needed.")]
	    [SerializeField]
	    private bool followOnStart = false;

	    [Tooltip("The Smoothing for the camera to follow the target")]
	    [SerializeField]
	    private float smoothSpeed = 0.125f;

		// ターゲットのキャッシュされた変換
		Transform cameraTransform;

		// ターゲットが失われたり、カメラが切り替えられた場合に再接続するために、内部でフラグを維持します
		bool isFollowing;

		// カメラオフセット用のキャッシュ
		Vector3 cameraOffset = Vector3.zero;


        #endregion

        #region MonoBehaviour Callbacks

        /// <summary>
        /// 初期化フェーズ中にUnityによってGameObjectで呼び出されるMonoBehaviourメソッド
        /// </summary>
        void Start()
		{
			// 必要に応じて、ターゲットの追跡を開始します。
			if (followOnStart)
			{
				OnStartFollowing();
			}
		}


		void LateUpdate()
		{
			// 変換ターゲットは、レベルの負荷で破壊されない場合があります。
			// そのため、新しいシーンをロードするたびにメインカメラが異なるコーナーケースをカバーし、それが発生したときに再接続する必要があります
			if (cameraTransform == null && isFollowing)
			{
				OnStartFollowing();
			}

			// フォローのみが明示的に宣言されています
			if (isFollowing) {
				Follow ();
			}
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// スタートフォローイベントを発生させます。
		//これは、フォローする内容がわからない場合に使用します。通常、インスタンスはフォトンネットワークによって管理されます。
		/// </summary>
		public void OnStartFollowing()
		{	      
			cameraTransform = Camera.main.transform;
			isFollowing = true;
			// 何もスムーズにせず、正しいカメラショットに直行します
			Cut();
		}																					

		#endregion

		#region Private Methods

		/// <summary>
		/// ターゲットをスムーズにフォロー
		/// </summary>
		void Follow()
		{
			cameraOffset.z = -distance;
			cameraOffset.y = height;
			
		    cameraTransform.position = Vector3.Lerp(cameraTransform.position, this.transform.position +this.transform.TransformVector(cameraOffset), smoothSpeed*Time.deltaTime);

		    cameraTransform.LookAt(this.transform.position + centerOffset);
		    
	    }

	   
		void Cut()
		{
			cameraOffset.z = -distance;
			cameraOffset.y = height;

			cameraTransform.position = this.transform.position + this.transform.TransformVector(cameraOffset);

			cameraTransform.LookAt(this.transform.position + centerOffset);
		}
		#endregion
	}
}