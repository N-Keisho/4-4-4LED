using UnityEngine;

public class EndGame: MonoBehaviour
{
   //ゲーム終了:ボタンから呼び出す
    public void Endgame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
#else
    Application.Quit();//ゲームプレイ終了
#endif
    }
}