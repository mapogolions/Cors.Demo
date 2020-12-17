### Cors Demo

##### How to use
- run application `dotnet run`
- go to the [google](https://google.com) page
- open dev tools and try the following requests

```js
fetch('http://localhost:5000')
    .then(payload => payload.text())
    .then(console.log)
    .catch(console.error);

fetch('http://localhost:5000', {
    headers: { "Content-Type": "application/json", "X-Allowed-Custom-Header": "" }
})
    .then(payload => payload.text())
    .then(console.log)
    .catch(console.error);

fetch('http://localhost:5000', {
    headers: { "Content-Type": "application/json", "X-Unknown-Custom-Header": "" }
})
    .then(payload => payload.text())
    .then(console.log)
    .catch(console.error);
```

#### Pitfalls
- If a resource set the `Content-Security-Policy` header, like [yandex](https://yandex.ru) or [github](https://github.com)
