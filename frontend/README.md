# Frontend – Garage-v2

## Beskrivning

Den här mappen innehåller två fristående frontend-övningar som skapades i samband med de två första momenten i frontend-kursen.

Istället för att skapa ett helt nytt projekt återanvändes Garage-v2 som tema för att visualisera fordon och parkeringsplatser med hjälp av HTML och CSS.

**OBS!** Frontend-delen är **inte kopplad** till Console Appens runtime utan fungerar som en separat visuell demonstration.

---

## Filer

| Fil | Beskrivning |
|-----|-------------|
| `flexbox-garage.html` | Visualisering av Garage-v2 med Flexbox |
| `flex-garage.css` | Styling för Flexbox-layouten |
| `grid-garage.html` | Visualisering av Garage-v2 med CSS Grid |
| `garage-grid.css` | Styling för Grid-layouten |

---

## Syfte

Övningarna skapades för att träna på:

- HTML5
- CSS3
- Flexbox
- Flex Wrap
- CSS Grid
- Grid Columns
- Grid Rows
- Grid Span

Samtidigt återanvänds Garage-v2:s tema för att skapa en mer realistisk frontend än ett vanligt övningsexempel.

---

## Starta övningarna

Öppna projektmappen och navigera till:

```text
frontend/
```

Öppna sedan valfri HTML-fil direkt i webbläsaren:

- `flexbox-garage.html`
- `grid-garage.html`

eller använd **Live Server** i Visual Studio Code.

---

## Designval enligt övningarna

Flexbox används för att visa fordon som responsiva parkeringscards.

CSS Grid används för att skapa ett 2D-parkeringsgarage med en körbana i mitten, där ett större VIP-fordon visar användningen av `grid-row: span` som tar en extra slot.

Frontend-delen är inspirerad av Garage-v2:s mockgarage för att skapa en tydlig koppling mellan Console Appen och webbvisualiseringen.