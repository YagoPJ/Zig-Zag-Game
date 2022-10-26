using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controleUI : MonoBehaviour {

	public GameObject telaIntrucoes; //referencia para alocação do gameobject la na unity
	public GameObject telaConfiguracoes; //idem acima
	public GameObject telaSobre;
	public GameObject telaMenu;
	// Start is called before the first frame update
	void Start()
	{

	}

	public void ChamarSobre() //chamar tela sobre
	{
		telaMenu.SetActive(false);//desativando o painel menu
		telaSobre.SetActive(true);//ativando o painel sobre
	}

	public void ChamarInstrucoes() //chamando a tela menu
	{
		telaMenu.SetActive(false); //desativando o painel sobre
		telaIntrucoes.SetActive(true); //ativando o painel menu
	}

	public void ChamarConfiguracoes()
	{
		telaMenu.SetActive (false);
		telaConfiguracoes.SetActive (true);
	}

	public void VoltarMenu ()
	{
		telaMenu.SetActive (true);
		telaSobre.SetActive (false);
		telaConfiguracoes.SetActive (false);
		telaIntrucoes.SetActive (false);
	}

	public void ChamarCenaJogar() //metodo para chamar a cena de jogo
	{
		SceneManager.LoadScene(1); //chamando a cena do jogo, 1 é devido a posição dela no building
	}

	public void ChamarCenaMenu() //chamando a tela menu do jogo, 0 é devido a posição dela no building
	{
		SceneManager.LoadScene(0); //carregando a cena menu no jogo
	}
}
