mergeInto(LibraryManager.library, {
  CopyToClipboard: function (strPtr) {
    const str = UTF8ToString(strPtr);
    if (navigator.clipboard && navigator.clipboard.writeText) {
      navigator.clipboard
        .writeText(str)
        .then(function () {
          console.log("Copied to clipboard:", str);
        })
        .catch(function (err) {
          console.error("Failed to copy:", err);
        });
    } else {
      var textarea = document.createElement("textarea");
      textarea.value = str;
      document.body.appendChild(textarea);
      textarea.select();
      document.execCommand("copy");
      document.body.removeChild(textarea);
    }
  },
});
