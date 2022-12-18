using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Extension;
using DG.Tweening;

[RequireComponent(typeof(AudioSource))]
public class Slicer : MonoBehaviour
{
    public AudioSource audioData;
    public int m;
    public int n;
    public int correctIndex;
    float x, y, a, d, NewWidth, NewHeight, l, f;
    private int c;
    public List<Sprite> pictures;
    

    private SpriteRenderer _spRenderer;
    public List<List<Sprite>> collection = new List<List<Sprite>>();
    

    [HideInInspector]
    public List<Parcha> pieceCollection = new List<Parcha>();
    public Parcha correctParcha;
    public static Slicer Instance;


    private void Awake()
    {
        Instance = this;
        NewWidth = 0;
        NewHeight = 0;
        _spRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        MakeSpritePieceCollection();
        MakePiecesCollection();
       
    }


    void MakeSpritePieceCollection()
    {
        foreach (Sprite pic in pictures)
        {
            _spRenderer.sprite = pic;
            //List<Sprite> sprites = _spRenderer.SliceSprite(_spRenderer.sprite.texture, m, n);
            //collection.Add(sprites);
        }
    }

    void MakePiecesCollection()
    {

        correctIndex = Random.Range(0, pictures.Count);
       
        _spRenderer.sprite = pictures[correctIndex];
        y = (float)(0 - (_spRenderer.sprite.rect.height / 2) / 100 + (_spRenderer.sprite.rect.height / n) / 200);
        int index = 0;
        for (int i = 0; i < n; i++)
        {
            
            x = (float)(0 - (_spRenderer.sprite.rect.width / 2) / 100 + (_spRenderer.sprite.rect.width / m) / 200);
            NewWidth = 0;
            for (int q = 0; q < m ; q++)
            {
                Sprite sp = Sprite.Create(_spRenderer.sprite.texture, new Rect(NewWidth, NewHeight, (_spRenderer.sprite.rect.width / m), (_spRenderer.sprite.rect.height / n)), new Vector2(0.5f, 0.5f));
                GameObject newObj = new GameObject();
                newObj.GetComponent<Transform>().position = new Vector2(x, y);
                newObj.AddComponent<SpriteRenderer>().sprite = sp;
                newObj.AddComponent<BoxCollider2D>();
                newObj.GetComponent<BoxCollider2D>().enabled = false;
                newObj.AddComponent<Parcha>();
                audioData = GetComponent<AudioSource>();
                newObj.GetComponent<Parcha>().audioData = audioData;
                newObj.GetComponent<Parcha>().Index = index;
                NewWidth += (_spRenderer.sprite.rect.width / m);
                x = (float)(x + (_spRenderer.sprite.rect.width / m) / 100);
                pieceCollection.Add(newObj.GetComponent<Parcha>());
                
                index++;
            }
            NewHeight += (_spRenderer.sprite.rect.height / n);

            y = (float)(y + (_spRenderer.sprite.rect.height / n) / 100);

            // obyekt yaratish +
            // Componentlarni qo'shish +
            // Rasmlarni ham qo'shish (Collection dan random olinadi)+
            // Script qo'shish
            // Parcha ni olib Index o'zgaruvchiga i ni berish
            _spRenderer.enabled = false;

        }
        AnimateAllPieces();
    }

    void AnimateAllPieces()
    {
        foreach (Parcha piece in pieceCollection)
        {
            piece.Scale(0.75f);
        }
        correctParcha = pieceCollection[Random.Range(0, pieceCollection.Count)];
        StartCoroutine(correctParcha.CorrectScale(0.9f));
    }
}