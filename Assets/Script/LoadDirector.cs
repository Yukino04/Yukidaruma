using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadDirector : MonoBehaviour
{
    //SE�p
    AudioSource SE;
    public AudioClip SE_ketteion;
    void Start()
    {
        //�~�߂��Q�[�����̎��Ԃ�߂��֐��̌Ăяo��
        GameOver.ReStartGame();

        this.SE = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        //�X�y�[�X�L�[�ŃV�[�����Z���N�g�V�[���ɕϊ�����
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetButtonDown("Button1"))
        {
            //���[�h�V�[����
            SceneManager.LoadScene("SelectScene");
        }
    }
}