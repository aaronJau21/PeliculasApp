import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PeliculasComponent } from './peliculas/peliculas.component';
import { CardsComponent } from './components/cards/cards.component';

@NgModule({
  declarations: [PeliculasComponent, CardsComponent],
  imports: [CommonModule],
})
export class PeliculasModule {}
