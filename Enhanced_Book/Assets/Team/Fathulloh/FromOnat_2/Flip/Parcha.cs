using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;



public class Parcha : MonoBehaviour, IPointerClickHandler
{
   public AudioSource audioData;
    public int Index;
    public int pictureIndex;
    public void OnPointerClick(PointerEventData eventData)
    {
       
        StartCoroutine(GetClick());
    }
    void Start()
    {
        
    }

    public void Scale(float val)
    {
        StartCoroutine(StartAnimation(val));
    }

    public IEnumerator CorrectScale(float val)
    {
        yield return new WaitForSeconds(0.5f);
        transform.DOScale(val, 0.5f);
    }
    IEnumerator StartAnimation(float val)
    {  
        transform.DOScale(val, 0.5f);

        yield return new WaitForSeconds(0.75f);

        if (this != Slicer.Instance.correctParcha)
        {
            for (int i = 0; i < Slicer.Instance.collection.Count; i++)
            {
                if (Slicer.Instance.correctIndex != i)
                {
                    transform.DORotate(new Vector3(0, 90, 0), 0.25f, 0);
                    yield return new WaitForSeconds(0.25f);
                    int pictureInd = Random.Range(0, Slicer.Instance.collection.Count);
                    List<Sprite> onePictureCollection = Slicer.Instance.collection[pictureInd];

                    GetComponent<SpriteRenderer>().sprite = onePictureCollection[Index];
                    pictureIndex = pictureInd;
                    transform.DORotate(new Vector3(0, 0, 0), 0.25f, 0);
                    yield return new WaitForSeconds(0.25f);
                }
                GetComponent<BoxCollider2D>().enabled = true;
            }
        }
        else
        {
            pictureIndex = Slicer.Instance.correctIndex;
            Debug.Log(Slicer.Instance.correctIndex);
        }
    }
    IEnumerator GetClick()
    {
        audioData.Play();
        transform.DORotate(new Vector3(0, 90, 0), 0.2f, 0);
        yield return new WaitForSeconds(0.2f);
        int pictureInd =  pictureIndex+1;
        if(pictureInd >= Slicer.Instance.collection.Count)
        {
            pictureInd = 0;
        }
       
        List<Sprite> onePictureCollection = Slicer.Instance.collection[pictureInd];
        GetComponent<SpriteRenderer>().sprite = onePictureCollection[Index];
        pictureIndex = pictureInd;
        transform.DORotate(new Vector3(0, 0, 0), 0.2f, 0);
        ChechCorrection();
    }

    void ChechCorrection()
    {
        int k = 0;
        foreach (Parcha par in Slicer.Instance.pieceCollection)
        {
            if (par.pictureIndex.Equals(Slicer.Instance.correctIndex))
            {
                k++;
                
            }
        }
        if (k.Equals(Slicer.Instance.pieceCollection.Count))
        {
            Debug.Log("WIN");
            foreach (Parcha aPiece in Slicer.Instance.pieceCollection)
            {
                aPiece.GetComponent<BoxCollider2D>().enabled = false;
                aPiece.transform.DOScale(1, 0.5f);
            }
        }
    }
}
