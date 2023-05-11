import { HttpClient } from '@angular/common/http';
import { ViewFlags } from '@angular/compiler/src/core';
import { Component } from '@angular/core';
import { delay } from 'rxjs/operators'; // ova se dodava

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  title = 'pokemon-api';
  opened = true;

  baseUrl = 'https://pokeapi.co/api/v2/';
  constructor(private http: HttpClient) {}

  getPokemon(pokemonId: number) {
    const url = `${this.baseUrl}pokemon/${pokemonId}`;

    //Observable
    this.http.get(url).subscribe(
      (val) => {
        console.log(val);
      },
      (error) => {
        console.log(error);
      }
    );

    //Promise
    const pokemon = this.http.get(url).toPromise();
    pokemon.then(console.log);
  }

  //Async/Await

  loading = false;

  async getPokemonAsync(pokemonId: number) {
    const url = `${this.baseUrl}pokemon/${pokemonId}`;
    this.loading = true;
    const pokemon = await this.http.get(url).toPromise();
    this.loading = false;
    console.table(pokemon);
  }

  getPokemonByUrl(url: string) {
    this.http.get(url).subscribe(
      (val) => {
        console.log(val);
      },
      (error) => {
        console.log(error);
      }
    );
  }

  pokemonList: any;
  getPokemonList(limit: number = 100, offset: number = 200) {
    const url = `${this.baseUrl}pokemon?limit=${limit}&offset=${offset}`;

    this.http.get(url).subscribe((response: any) => {
      debugger;
      this.pokemonList = response.results;
    });
  }
}
