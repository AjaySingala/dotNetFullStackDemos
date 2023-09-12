import fetch from 'node-fetch';

fetch('http://localhost:4000', {
  method: 'POST',
  headers: { 'Content-Type': 'application/json' },
  body: JSON.stringify({ query: `
    query {
        games {
            id,
            title,
            platform
        }
    }` 
  }),
})
.then(res => res.json())
.then(res => console.log(res.data));
