$(document).ready(function () {
    var ticketsContainer = $("#ticketsContainer");
    var ticketIndex = -1;

    $("#addTicket").click(function () {
        var deleteTicketBtn = $(`#delete-ticket-${ticketIndex}`);
        deleteTicketBtn.prop("disabled", true);

        ticketIndex++;
        var ticketHtml = `

            <div class="col-12">
  <div class="card mb-4">
    <div class="card-header">
      <h3 class="card-title">بلیت ${ticketIndex + 1}</h3>
    </div>

    <div class="card-body">
      <div class="ticket" id="ticket-${ticketIndex}">
        <div class="row mb-4">
          <div class="col-md-6">
            <div class="form-group">
              <label
                class="form-label"
                for="Command_Tickets_${ticketIndex}__Title"
                >عنوان</label
              >
              <input
                type="text"
                class="form-control"
                data-val="true"
                data-val-required="این فیلد نمیتواند خالی باشد"
                id="Command_Tickets_${ticketIndex}__Title"
                name="Command.Tickets[${ticketIndex}].Title"
                value=""
              />
              <span
                class="error field-validation-valid"
                data-valmsg-for="Command.Tickets[${ticketIndex}].Title"
                data-valmsg-replace="true"
              ></span>
            </div>
          </div>
          <div class="col-md-6">
            <div class="form-group">
              <label
                class="form-label"
                for="Command_Tickets_${ticketIndex}__Number"
                >تعداد</label
              >
              <input
                type="text"
                class="form-control"
                data-val="true"
                data-val-required="این فیلد نمیتواند خالی باشد"
                id="Command_Tickets_${ticketIndex}__Number"
                name="Command.Tickets[${ticketIndex}].Number"
                value=""
              />
              <span
                class="error field-validation-valid"
                data-valmsg-for="Command.Tickets[${ticketIndex}].Number"
                data-valmsg-replace="true"
              ></span>
            </div>
          </div>
        </div>

        <div class="row mb-4">
          <div class="col-md-6">
            <div class="form-group">
              <label
                class="form-label"
                for="Command_Tickets_${ticketIndex}__StartTime"
                >تاریخ شروع</label
              >
              <input
                type="text"
                class="form-control persianDateInput pwt-datepicker-input-element"
                id="Command_Tickets_${ticketIndex}__StartTime"
                name="Command.Tickets[${ticketIndex}].StartTime"
                value=""
              />
              <span
                class="error field-validation-valid"
                data-valmsg-for="Command.Tickets[${ticketIndex}].StartTime"
                data-valmsg-replace="true"
              ></span>
            </div>
          </div>
          <div class="col-md-6">
            <div class="form-group">
              <label
                class="form-label"
                for="Command_Tickets_${ticketIndex}__EndTime"
                >تاریخ پایان</label
              >
              <input
                type="text"
                class="form-control persianDateInput pwt-datepicker-input-element"
                id="Command_Tickets_${ticketIndex}__EndTime"
                name="Command.Tickets[${ticketIndex}].EndTime"
                value=""
              />
              <span
                class="error field-validation-valid"
                data-valmsg-for="Command.Tickets[${ticketIndex}].EndTime"
                data-valmsg-replace="true"
              ></span>
            </div>
          </div>
        </div>
        <div class="row mb-4">
          <div class="col-md-12">
            <div class="form-group">
              <label
                class="form-label"
                for="Command_Tickets_${ticketIndex}__Description"
                >توضیحات</label
              >
              <textarea
                class="form-control"
                rows="5"
                id="Command_Tickets_${ticketIndex}__Description"
                name="Command.Tickets[${ticketIndex}].Description"
              ></textarea>
              <span
                class="error field-validation-valid"
                data-valmsg-for="Command.Tickets[${ticketIndex}].Description"
                data-valmsg-replace="true"
              ></span>
            </div>
          </div>
        </div>

        <div class="row mb-4">
          <div class="col-md-6">
            <div class="form-group">
              <label
                class="form-label"
                for="Command_Tickets_${ticketIndex}__Price"
                >قیمت</label
              >
              <input
                type="text"
                class="form-control"
                data-val="true"
                data-val-number="The field Price must be a number."
                data-val-required="این فیلد نمیتواند خالی باشد"
                id="Command_Tickets_${ticketIndex}__Price"
                name="Command.Tickets[${ticketIndex}].Price"
                value=""
              />
              <span
                class="error field-validation-valid"
                data-valmsg-for="Command.Tickets[${ticketIndex}].Price"
                data-valmsg-replace="true"
              ></span>
            </div>
          </div>

          <div class="col-md-6">
            <div class="form-group">
              <label class="form-label">کد تخفیف</label>
              <div class="row">
                <button
                  type="button"
                  data-ticket-index="${ticketIndex}"
                  class="btn btn-label-primary col-md-4 addDiscountCode"
                >
                  افزودن کد تخفیف
                </button>

              </div>
            </div>
          </div>
          <div class="discountCodesContainer"></div>
        </div>
        <button type="button" class="btn btn-danger deleteTicket" id="delete-ticket-${ticketIndex}">حذف بلیت</button>

      </div>

      <div class="discountCodesContainer"></div>
    </div>
  </div>
</div>
            `;
        ticketsContainer.append(ticketHtml);
    });

    ticketsContainer.on("click", ".deleteTicket", function () {
        var ticket = $(this).closest(".col-12");
        var deleteTicketBtn = $(`#delete-ticket-${ticketIndex-1}`);
        deleteTicketBtn.prop("disabled", false);
        ticketIndex--;
        ticket.remove();
    });

    ticketsContainer.on("click", ".addDiscountCode", function () {
        var ticketIndex = $(this).data("ticket-index");
        var discountCodesContainer = $(`#ticket-${ticketIndex} .discountCodesContainer`);
        var discountCodeIndex = discountCodesContainer.children().length;
        var discountCodeHtml = `<div class="discountCode">
                                                        <div class="mb-3">
                  <div class="repeater-wrapper pt-0 pt-md-4">
                    <div class="d-flex border rounded position-relative pe-0">
                      <div class="row w-100 m-0 p-3">
                        <div class="col-md-6">
                          <div class="form-group">
                                    <label class="form-label" for="Command_Tickets_${ticketIndex}_DiscountCodes_${discountCodeIndex}__Code"
                              >کد تخفیف</label
                            >
                            <input
                              type="text"
                              class="form-control"
                              data-val="true"
                              data-val-required="این فیلد نمیتواند خالی باشد"
                                      id="Command_Tickets_${ticketIndex}_DiscountCodes_${discountCodeIndex}__Code"
                                      name="Command.Tickets[${ticketIndex}].DiscountCodes[${discountCodeIndex}].Code"
                              value=""
                            />
                            <span
                              class="error field-validation-valid"
                                      data-valmsg-for="Command.Tickets[${ticketIndex}].DiscountCodes[${discountCodeIndex}].Code"
                              data-valmsg-replace="true"
                            ></span>
                          </div>
                        </div>
                        <div class="col-md-6">
                          <div class="form-group">
                            <label
                              class="form-label"
                                      for="Command_Tickets_${ticketIndex}_DiscountCodes_${discountCodeIndex}__DiscountRate"
                              >درصد تخفیف</label
                            >
                            <input
                              type="text"
                              class="form-control"
                              data-val="true"
                              data-val-number="The field DiscountRate must be a number."
                              data-val-required="این فیلد نمیتواند خالی باشد"
                                      id="Command_Tickets_${ticketIndex}_DiscountCodes_${discountCodeIndex}__DiscountRate"
                                      name="Command.Tickets[${ticketIndex}].DiscountCodes[${discountCodeIndex}].DiscountRate"
                              value=""
                            />
                            <span
                              class="error field-validation-valid"
                                      data-valmsg-for="Command.Tickets[${ticketIndex}].DiscountCodes[${discountCodeIndex}].DiscountRate"
                              data-valmsg-replace="true"
                            ></span>
                          </div>
                        </div>

                        <div class="col-md-6">
                          <div class="form-group">
                            <label
                              class="form-label"
                                      for="Command_Tickets_${ticketIndex}_DiscountCodes_${discountCodeIndex}__Count"
                              >تعداد</label
                            >
                            <input
                              type="text"
                              class="form-control"
                              data-val="true"
                              data-val-required="این فیلد نمیتواند خالی باشد"
                                      id="Command_Tickets_${ticketIndex}_DiscountCodes_${discountCodeIndex}__Count"
                                              name="Command.Tickets[${ticketIndex}].DiscountCodes[${discountCodeIndex}].Count"
                              value=""
                            />
                            <span
                              class="error field-validation-valid"
                                      data-valmsg-for="Command.Tickets[${ticketIndex}].DiscountCodes[${discountCodeIndex}].Count"
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
                                              </div>`;
        discountCodesContainer.append(discountCodeHtml);
    });

    ticketsContainer.on("click", ".deleteDiscountCode", function () {
        $(this).closest(".discountCode").remove();
    });
});