$(document).ready(function () {
    var container = $("#discountCodesContainer");
    var addButton = $("#addDiscountCode");

    addButton.click(function (e) {
        e.preventDefault();
        var index = container.children().length;
        var discountCodeInput = `
                                                            <div class="mb-3">
          <div class="repeater-wrapper pt-0 pt-md-4">
            <div class="d-flex border rounded position-relative pe-0">
              <div class="row w-100 m-0 p-3">
                <div class="col-md-6">
                  <div class="form-group">
                    <label class="form-label" for="Command_DiscountCodes_${index}__Code"
                      >کد تخفیف</label
                    >
                    <input
                      type="text"
                      class="form-control"
                      data-val="true"
                      data-val-required="این فیلد نمیتواند خالی باشد"
                      id="Command_DiscountCodes_${index}__Code"
                      name="Command.DiscountCodes[${index}].Code"
                      value=""
                    />
                    <span
                      class="error field-validation-valid"
                      data-valmsg-for="Command.DiscountCodes[${index}].Code"
                      data-valmsg-replace="true"
                    ></span>
                  </div>
                </div>
                <div class="col-md-6">
                  <div class="form-group">
                    <label
                      class="form-label"
                      for="Command_DiscountCodes_${index}__DiscountRate"
                      >درصد تخفیف</label
                    >
                    <input
                      type="text"
                      class="form-control"
                      data-val="true"
                      data-val-number="The field DiscountRate must be a number."
                      data-val-required="این فیلد نمیتواند خالی باشد"
                      id="Command_DiscountCodes_${index}__DiscountRate"
                      name="Command.DiscountCodes[${index}].DiscountRate"
                      value=""
                    />
                    <span
                      class="error field-validation-valid"
                      data-valmsg-for="Command.DiscountCodes[${index}].DiscountRate"
                      data-valmsg-replace="true"
                    ></span>
                  </div>
                </div>

                <div class="col-md-6">
                  <div class="form-group">
                    <label
                      class="form-label"
                      for="Command_DiscountCodes_${index}__Count"
                      >تعداد</label
                    >
                    <input
                      type="text"
                      class="form-control"
                      data-val="true"
                      data-val-required="این فیلد نمیتواند خالی باشد"
                      id="Command_DiscountCodes_${index}__Count"
                      name="Command.DiscountCodes[${index}].Count"
                      value=""
                    />
                    <span
                      class="error field-validation-valid"
                      data-valmsg-for="Command.DiscountCodes[${index}].Count"
                      data-valmsg-replace="true"
                    ></span>
                  </div>
                </div>
              </div>
              <div
                class="d-flex flex-column align-items-center justify-content-between border-start p-2"
              >
                <i
                  class="bx bx-x fs-4 text-muted cursor-pointer deleteDiscountCode"
                ></i>
              </div>
            </div>
          </div>
        </div>
                                                          `;
        container.append(discountCodeInput);
    });

    container.on("click", ".deleteDiscountCode", function () {
        $(this).closest(".mb-3").remove();
    });
});