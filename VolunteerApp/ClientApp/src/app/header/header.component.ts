import { Component, ViewChild, ElementRef, HostListener } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
})
export class HeaderComponent {
  @ViewChild('menuBtn', { static: true }) menuBtn: ElementRef | undefined;
  @ViewChild('menuBody', { static: true }) menuBody: ElementRef | undefined;
  arr: number[] = [1, 2, 3, 4];
  bodyLockToggle() {
    document.querySelector('body')!.classList.contains('lock')
      ? document.querySelector('body')!.classList.remove('lock')
      : document.querySelector('body')!.classList.add('lock');
  }

  toggleMenu() {
    this.bodyLockToggle();
    this.menuBtn?.nativeElement.classList.toggle('menu-open');
    this.menuBody?.nativeElement.classList.toggle('menu-open');
  }
  openMenu() {
    document.querySelector('body')!.classList.add('lock');
    this.menuBtn?.nativeElement.classList.add('menu-open');
    this.menuBody?.nativeElement.classList.toggle('menu-open');
  }
  closeMenu() {
    document.querySelector('body')!.classList.remove('lock');
    this.menuBtn?.nativeElement.classList.remove('menu-open');
    this.menuBody?.nativeElement.classList.toggle('menu-open');
  }

  // @HostListener('window:resize', ['$event'])
  // onWindowResize(){
  //   const viewportWidth  = Math.max(document.documentElement.clientWidth, window.innerWidth);
  //   if(viewportWidth <= 500){

  //   }
  // }
}
